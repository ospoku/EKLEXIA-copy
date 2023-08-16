
using Microsoft.AspNetCore.Mvc;
using EKLEXIA.Data;
using EKLEXIA.ViewModels;

namespace EKLEXIA.ViewComponents
{
    public class Members : ViewComponent
    {
        public readonly XContext xct;
        public Members(XContext XContext)
        {
            xct = XContext;
        }
        public IViewComponentResult Invoke()
        {
            var MembersList = xct.Members.Where(m => m.IsDeleted == false).Select(m => new MembersVM
            {
                MemberId = m.MemberId,
                Telephone = m.Telephone,
                Hometown = m.Hometown,
                Fullname = m.Fullname,
                DateofBirth = m.DoB,
                GenderId = m.Gender.Name,
                Age = m.Age,
                RegionId = m.RegionId,
                Address = m.Address,
                IDNumber = m.IDNumber,

                CareerId = m.CareerId,
                Photo = m.Photo,

            }).ToList();
            return View(MembersList);
        }
    }
}
@section Scripts
{
    <script>
        function functionConfirm(event) {
        const swalWithBootstrapButtons = Swal.mixin({
        customClass:
            {
            confirmButton: 'btn btn-success',
                    cancelButton: 'btn btn-danger'
                },
                buttonsStyling: false
            })

        swalWithBootstrapButtons.fire({
        title: 'Emin misiniz?',
            text: "Bu işlem geri alınamaz!",
            icon: 'warning',
            showCancelButton: true,
            confirmButtonText: 'Evet, sil!',
            cancelButtonText: 'Hayır, iptal',
            reverseButtons: true,
            timer: 3000
        }).then((result) => {
        if (result.isConfirmed)
        {
                $("form").submit();

            swalWithBootstrapButtons.fire({
            title: 'Silindi!',
                    text: 'Kategori silindi.',
                    icon: 'success',
                    timer: '2000'
                    }
                )
            } else if (
                /* Read more about handling dismissals below */
                result.dismiss === Swal.DismissReason.cancel
            ) {
        swalWithBootstrapButtons.fire(
            'İptal edildi',
            '',
            'error'
        )
            }
})
    }
</ script >
    < td >< div >< form asp - action = "Delete" method = "post" asp - controller = "Category" asp - route - id = "@item.Id" >< button type = "button" class= "btn btn-danger" onclick = "return functionConfirm(this)" > Delete </ button ></ form >
                                    </ div >
                                </ td >