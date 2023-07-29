using EKLEXIA.Data;
using EKLEXIA.Models;
using Microsoft.AspNet.SignalR;
using Microsoft.Data.SqlClient;

namespace EKLEXIA.Notice
{
    public class NotificationComponent

    {
        public readonly XContext ctx;
        public readonly IConfiguration config;
        public NotificationComponent(XContext context,IConfiguration configuration )
        {
            ctx = context;
            config = configuration;
        }

        //Here we will add a function for register notification (will add sql dependency)
        public void RegisterNotification(DateTime currentTime)
        {
            string conStr = config.GetConnectionString("ECX");
            string sqlCommand = @"SELECT [ContactID],[ContactName],[ContactNo] from [dbo].[Contacts] where [CreatedDate] > @CreatedDate";
            //you can notice here I have added table name like this [dbo].[Contacts] with [dbo], its mendatory when you use Sql Dependency
            using (SqlConnection con = new SqlConnection(conStr))
            {
                SqlCommand cmd = new SqlCommand(sqlCommand, con);
                cmd.Parameters.AddWithValue("@CreatedDate", currentTime);
                if (con.State != System.Data.ConnectionState.Open)
                {
                    con.Open();
                }
                cmd.Notification = null;
                SqlDependency sqlDep = new SqlDependency(cmd);
                sqlDep.OnChange += sqlDep_OnChange;
                //we must have to execute the command here
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    // nothing need to add here now
                }
            }
        }

        void sqlDep_OnChange(object sender, SqlNotificationEventArgs e)
        {
            //or you can also check => if (e.Info == SqlNotificationInfo.Insert) , if you want notification only for inserted record
            if (e.Type == SqlNotificationType.Change)
            {
                SqlDependency sqlDep = sender as SqlDependency;
                sqlDep.OnChange -= sqlDep_OnChange;

                //from here we will send notification message to client
                var notificationHub = GlobalHost.ConnectionManager.GetHubContext<NotificationHub>();
                notificationHub.Clients.All.notify("added");
                //re-register notification
                RegisterNotification(DateTime.Now);
            }
        }

        public List<Member> GetContacts(DateTime afterDate)
        {

            return ctx.Members.Where(a => a.CreatedDate > afterDate).OrderByDescending(a => a.CreatedDate).ToList();
        }
    }
}
