let hudBrowser = null,
    hitmarker = false;

mp.events.add("Client:HUD:showHUD", (level, kills, deaths, experience, maxExperience) => {
    if (hudBrowser == null) {
        hudBrowser = mp.browsers.new("package://cef/HUD/Hud.html");
        hudBrowser.execute(`showHUD();`);
        hudBrowser.execute(`setLevel(${level});`);
        hudBrowser.execute(`setKills(${kills});`);
        hudBrowser.execute(`setDeaths(${deaths});`);
        hudBrowser.execute(`updateRatio(${kills}, ${deaths});`);
        hudBrowser.execute(`setExperience(${experience});`);
        hudBrowser.execute(`setMaxExperience(${maxExperience});`);
    }
});

mp.events.add("playerWeaponShot", (targetPosition, targetEntity) => {
    if (hudBrowser == null || targetEntity == null || hitmarker) return;
    hudBrowser.execute(`triggerHitmarker();`);
});

mp.keys.bind(0x74, false, function() {
    if (hitmarker) mp.gui.chat.push("Hitmarker deaktiviert.");
    else mp.gui.chat.push("Hitmarker aktiviert.");
    hitmarker = !hitmarker;
});

mp.keys.bind(0x73, false, function() {
    if (hudBrowser == null) return;
    hudBrowser.execute(`toggleCrosshair();`);
});

mp.events.add("Client:Admin:toggleAdminMode", () => {
    if (hudBrowser != null) {
        hudBrowser.execute(`toggleAdminMode();`);
    }
});

mp.events.add("Client:HUD:DeathEvent", (teamKill, killerName, kills, deaths, victimName) => {
    if (hudBrowser != null) {
        hudBrowser.execute(`deathEvent(${teamKill}, "${killerName}", "${kills}", "${deaths}", "${victimName}");`);
    }
});

mp.events.add("Client:Kick:Kick", (reason) => {
    mp.events.callRemote("Server:Kick:Kick", reason);
});

mp.events.add("Client:HUD:RespawnEvent", () => {
    if (hudBrowser != null) {
        hudBrowser.execute(`respawnEvent();`);
    }
});

mp.events.add("Client:HUD:KillEvent", (teamKill, killerName, kills, deaths, victimName, driveby) => {
    if (hudBrowser != null) {
        hudBrowser.execute(`killEvent(${teamKill}, "${killerName}", "${kills}", "${deaths}", "${victimName}", ${driveby});`);
    }
});

mp.events.add("Client:HUD:setExperience", experience => {
    if (hudBrowser != null) {
        hudBrowser.execute(`setExperience(${experience});`);
    }
});

mp.events.add("Client:HUD:setKills", kills => {
    if (hudBrowser != null) {
        hudBrowser.execute(`setKills(${kills});`);
    }
});

mp.events.add("Client:HUD:setDeaths", deaths => {
    if (hudBrowser != null) {
        hudBrowser.execute(`setDeaths(${deaths});`);
    }
});

mp.events.add("Client:HUD:LevelUP", (level, maxExperience) => {
    if (hudBrowser != null) {
        hudBrowser.execute(`levelUp(${level}, ${maxExperience});`);
    }
});

mp.events.add("Client:HUD:ModMessage", (title, message, lengthMS) => {
    if (hudBrowser != null) {
        hudBrowser.execute(`sendPopup("mod", "${title}", "${message}", ${lengthMS});`);
    }
});

mp.events.add("Client:HUD:SystemMessage", (title, message, lengthMS) => {
    if (hudBrowser != null) {
        hudBrowser.execute(`sendPopup("system", "${title}", "${message}", ${lengthMS});`);
    }
});