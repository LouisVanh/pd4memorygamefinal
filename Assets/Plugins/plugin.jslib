mergeInto(LibraryManager.library, 
{
    UpdateName1: function()
    {
        var player1 = parent.document.getElementById('fname');
        var returnStr = player1.value;
        var buffer = _malloc(returnStr.length + 1);
        writeStringToMemory(returnStr, buffer);
        return buffer;
    },
    UpdateName2: function()
    {
        var player2 = parent.document.getElementById('hname');
        var returnStr = player2.value;
        var buffer = _malloc(returnStr.length + 1);
        writeStringToMemory(returnStr, buffer);
        return buffer;
    },
    StartGameThroughButton: function()
    {
        // Replace 'Engine' with the name of the GameObject in Unity that has the script
        // Replace 'StartGameButtonClicked' with the name of the method you want to call in your C# script
        SendMessage('Engine', 'StartGameButtonClicked');
    }
});
