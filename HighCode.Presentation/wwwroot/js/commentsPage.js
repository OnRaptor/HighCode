$("[data-btnreplyid]").each(function(){
    $(this).click(()=>{
        var commentContainer = $(this).parent().parent().parent();
        commentContainer.find(".reply-container").toggle();
    })
})

$("[data-btnnewreplyid]").each(function(){
    $(this).click(()=>{
        var commentContainer = $(`[data-crcommentid=${$(this).data('origcomment')}]`);
        console.log(commentContainer)
        commentContainer.find(".newreplyhrepliername").val($(this).data('authorname'))
        commentContainer.find(".newreplyhreplierlabel").text('В ответ на ' + $(this).data('authorname'))
    })
})
$("[data-btncommentsid]").each(function(){
    $(this).click(()=> {
        $(`[data-commentsid=${$(this).data('btncommentsid')}]`).toggle()
    });
})

$(".btnlike").each(function(){
    $(this).click(()=> {
        var btnlike = $(this);
        var btndislike =  $(`.btndislike[data-commentid=${$(this).data('commentid')}]`);
        $.ajax({
            url: "/CodeTasks/ReactForComment",
            method: 'POST',             /* Метод запроса (post или get) */
            data: {
                commentId : $(this).data('commentid'),
                reaction: 0
            },
            success: function (data, status) {
                if (data !== false) {
                    btnlike.children("span").text(data['likes']);
                    btndislike.children("span").text(data['dislikes']);
                }
                console.log(data);
            },
            error: function (data, status){
                alert("Не удалось поставить лайк")
            }
        })
    });
})

$(".btndislike").each(function(){
    $(this).click(()=> {
        var btndislike = $(this);
        var btnlike =  $(`.btnlike[data-commentid=${$(this).data('commentid')}]`);
        $.ajax({
            url: "/CodeTasks/ReactForComment",
            method: 'POST',             /* Метод запроса (post или get) */
            data: {
                commentId : $(this).data('commentid'),
                reaction: 1
            },
            success: function (data, status) {
                if (data !== false) {
                    btnlike.children("span").text(data['likes']);
                    btndislike.children("span").text(data['dislikes']);
                }
                console.log(data);
            },
            error: function (data, status){
                alert("Не удалось поставить дизлайк")
            }
        })
    });
})