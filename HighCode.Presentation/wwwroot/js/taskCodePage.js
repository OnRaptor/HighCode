var checkBtn = $("#checkBtn")
var sendBtn = $("#sendBtn")

checkBtn.click(_ =>{
    $.ajax({
        url: "/CodeTaskSolutions/TestCode",
        method: 'get',             /* Метод запроса (post или get) */
        dataType: 'json',          /* Тип данных в ответе (xml, json, script, html). */
        data: {
            codeTaskId: checkBtn.data("codetaskid"),
            code: $("#userCode").html()
        },
        success: function (data, status) {
            if (data === true){
                $("#codeStatus").text("Код прошел тестирование")
            }
        }
    })
})