var checkBtn = $("#checkBtn")
var sendBtn = $("#sendBtn")

checkBtn.click(_ =>{
    var code = window.codeEditor.getModel().getValue()
    $.ajax({
        url: "/CodeTaskSolutions/TestCode",
        method: 'get',             /* Метод запроса (post или get) */
        dataType: 'text',          /* Тип данных в ответе (xml, json, script, html). */
        data: {
            codeTaskId: checkBtn.data("codetaskid"),
            code: code
        },
        success: function (data, status) {
            $("#codeStatus").text(data)
            if (data === true){
                $("#codeStatus").text("Код прошел тестирование")
            }
        },
        error: function (data, status){
            $("#codeStatus").text(data)
        }
    })
})