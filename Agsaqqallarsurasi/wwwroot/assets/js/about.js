$('.tabContent button').click(function() {
    $(this).next('.tab-desc').fadeToggle("slow");
})
$('.download-btn').click(function(){
    let fileUrl = $(this).closest('.tabContent').find('.file-download-btn').data('file-url');
    if(fileUrl) {
        let downloadLink = $('<a></a>');
        downloadLink.attr('href', fileUrl); 
        downloadLink.attr('download', ''); 
        downloadLink.css('display', 'none'); 
        $('body').append(downloadLink); 
        downloadLink[0].click(); 
        downloadLink.remove(); 
    } else {
        console.log('File URL not found!');
    }
});