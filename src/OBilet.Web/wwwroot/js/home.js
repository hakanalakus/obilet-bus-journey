
$(function () {
    const ajax = {
        url: "/Home/GetBusLocations",
        dataType:"json"
    }
    $('#SourceId').select2({ minimumInputLength: 2, placeholder: "Please select the source ...",ajax });
    $('#DestinationId').select2({ minimumInputLength: 2, placeholder: "Please select the destination ...",ajax });
});

function setDate(tomorrow) {
    const today = new Date();
    const elDate = document.getElementById("Date");

    if (!tomorrow) {
        elDate.value = today.toISOString().split('T')[0];
    }
    else {
        const tomorrow = new Date(today.getTime() + (24 * 60 * 60 * 1000));
        elDate.value = tomorrow.toISOString().split('T')[0];
    }
}

function changeValues() {

    
    const src = $('#SourceId');
    const dest = $('#DestinationId');
    const optSrc = src.find(`option[value='${src.val()}']`);
    const optTarget = dest.find(`option[value='${dest.val()}']`);

    optSrc.detach();
    optTarget.detach();

    $('#SourceId').append(optTarget).trigger('change');
    $('#DestinationId').append(optSrc).trigger('change');
}


