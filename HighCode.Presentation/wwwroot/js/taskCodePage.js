var checkBtn = $("#checkBtn")
var saveBtn = $("#saveBtn")
var sendBtn = $("#sendBtn")

displayTestResult = (testResult) => {
    const out = [];
    if (!testResult.useRawOutput){
        out.push(`Пройдено тестов ${testResult.testsPassed} из ${testResult.testsTotalCount}\n`)
        out.push(testResult.output)
    }
    else{
        out.push(testResult.output)
    }
    $("#codeStatus").text(out.join("\n"))
    $("#statusBorder").toggle(true);
}

checkBtn.click(_ =>{
    var code = window.codeEditor.getModel().getValue()
    $.ajax({
        url: "/CodeTaskSolutions/TestCode",
        method: 'POST',             /* Метод запроса (post или get) */
        data: {
            codeTaskId: checkBtn.data("codetaskid"),
            code: code
        },
        success: function (data, status) {
            console.log(data)
            displayTestResult(data)
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
                $("#codeStatus").text(data)
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
            displayTestResult(data);
        },
        error: function (data, status){
            $("#statusBorder").toggle(true);
            $("#codeStatus").text(data);
        }
    })
})