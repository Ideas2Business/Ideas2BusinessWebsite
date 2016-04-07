$(document).ready(function () {
    $('#homeContent div').hide();
    $('#homeContent div').fadeIn('slow');
});

function ChangePt() {
    $.ajax({
        url: "/Home/ChangePt",
        type: "GET",
        success: function () {
            window.location.reload();
        }
    });
}

function ChangeEn() {
    $.ajax({
        url: "/Home/ChangeEn",
        type: "GET",
        success: function () {
            window.location.reload();
        }
    });
    
}

function submitEmailForm(type) {
    $.ajax({
        url: "/Home/SendEmail",
        type: "POST",
        cache: false,
        data: { name: $('#inputName').val(), email: $('#inputEmail').val(), message: $('#textAreaMessage').val() },
        success: function () {
            if (type == 'en') {
                alert('Thank you for contacting us. We will answer your message as soon as possible.');
            }
            else {
                alert('Obrigado pela sua mensagem! Assim que possível, entraremos em contato.');
            }
            window.location.reload();
        }
    });
}

function selectMenuItem(menuItem) {
    $('.selected').removeClass('selected');
    switch (menuItem) {
        case 'home':
            $('#menuHome').addClass('selected');
            return;
        case 'about':
            $('#menuAboutUs').addClass('selected');
            return;
        case 'team':
            $('#menuTeam').addClass('selected');
            return;
        case 'contact':
            $('#menuContactUs').addClass('selected');
            return;
    }
}
