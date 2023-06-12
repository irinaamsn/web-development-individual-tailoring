$("#createbtn").click(function () {
    alert('here');
    var b = @Model.IsCreate;

    if (b == "1") {
        Swal.fire({
            icon: 'error',
            title: 'Oops...',
            text: 'Вы уже записаны!',
            footer: '<a href="@Url.Action("Signs","PersonalAccount", new{name= User.Identity.Name})">Чтобы записаться, отмените текущую запись</a>'

        })


    }
    if (b == "0") {

        document.location.href = '@Url.Action("CreateSignUp","PersonalAccount", new{idSp= sp.Id})';
    }


});