function GetAntiForgeryToken(containerId) {
    var tokenWindow = window;
    var tokenName = "__RequestVerificationToken";
    var tokenField = $(containerId).find("input[type='hidden'][name='" + tokenName + "']");
    if (tokenField.length == 0) { return null; }
    else {
        return {
            name: tokenName,
            value: tokenField.val()
        };
    }
};