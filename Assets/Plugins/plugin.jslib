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
        var player1 = parent.document.getElementById('hname');
        var returnStr = player1.value;
        var buffer = _malloc(returnStr.length + 1);
        writeStringToMemory(returnStr, buffer);
        return buffer;
    }
});