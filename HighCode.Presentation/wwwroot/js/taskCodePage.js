var checkBtn = $("#checkBtn")
var saveBtn = $("#saveBtn")
var sendBtn = $("#sendBtn")

checkBtn.click(_ =>{
    var code = window.codeEditor.getModel().getValue()
    $.ajax({
        url: "/CodeTaskSolutions/TestCode",
        method: 'POST',             /* Метод запроса (post или get) */
        dataType: 'text',          /* Тип данных в ответе (xml, json, script, html). */
        data: {
            codeTaskId: checkBtn.data("codetaskid"),
            code: code
        },
        success: function (data, status) {
            console.log(data)
            $("#codeStatus").text(data)
            $("#statusBorder").toggle(true);
        },
        error: function (data, status){
            $("#codeStatus").text(status)
        }
    })
})

saveBtn.click(_ =>{
    var code = window.codeEditor.getModel().getValue();
    $.ajax({
        url: "/CodeTaskSolutions/SaveCode",
        method: 'POST',             /* Метод запроса (post или get) */
        data: {
            codeTaskId: checkBtn.data("codetaskid"),
            code: code
        },
        success: function (data, status) {
            if (status){
                $("#codeStatus").text(status)
                $("#statusBorder").toggle(true);
            }
        },
        error: function (data, status){
            $("#codeStatus").text(status)
        }
    })
})

sendBtn.click(_ =>{
    var code = window.codeEditor.getModel().getValue();
    $.ajax({
        url: "/CodeTaskSolutions/Publish",
        method: 'POST',             /* Метод запроса (post или get) */
        data: {
            codeTaskId: checkBtn.data("codetaskid"),
            code: code
        },
        success: function (data, status) {
            $("#statusBorder").toggle(true);
            $("#codeStatus").text(data);
        },
        error: function (data, status){
            $("#statusBorder").toggle(true);
            $("#codeStatus").text(data);
        }
    })
})