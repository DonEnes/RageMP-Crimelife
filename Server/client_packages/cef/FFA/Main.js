let ffaBrowser = null;

mp.events.add("Client:FFA:openBrowser", arena => {
    if (ffaBrowser == null) {
        ffaBrowser = mp.browsers.new("package://cef/FFA/index.html");
        ffaBrowser.execute(`updateArena('${arena}');`);
    }
});

mp.events.add("Client:FFA:destroyBrowser", () => {
    if (ffaBrowser != null) {
        ffaBrowser.destroy();
        ffaBrowser = null;
    }
});

mp.events.add("Client:FFA:setFFA", arenaname => {
    mp.events.callRemote("Server:FFA:setFFA", arenaname);
    if (ffaBrowser != null) {
        ffaBrowser.destroy();
        ffaBrowser = null;
    }
});

mp.keys.bind(0x45, false, function() {
    if (mp.gui.cursor.visible) return;
    mp.events.callRemote("Server:Keyhandler:E")
});