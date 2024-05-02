window.initEditors = (code,unitTestCode, theme) => {
    require.config({ paths: { vs: '/lib/vs' } });
    require(['vs/editor/editor.main'], function () {
        window.codeEditor = monaco.editor.create(document.getElementById('container1'), {
            value: code,
            language: 'csharp',
            minimap: { enabled: false },
            autoIndent: 'full',
            theme: theme
        });
        window.unitTestReader = monaco.editor.create(document.getElementById('container2'), {
            value: unitTestCode,
            language: 'csharp',
            minimap: { enabled: false },
            readOnly: true,
            theme: theme
        });
    });
}

window.getCodeFromEditor = () => {
    return window.codeEditor.getModel().getValue()
}