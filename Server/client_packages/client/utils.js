let usingWestOrAidKit = false,
    usingRepairKit = false,
    chatVisible = true,
    lastInteract = 0;

mp.events.add("Client:Ped:createGaragePeds", (pedArray) => {
    pedArray = JSON.parse(pedArray);
    for (var i in pedArray) {
        spawnPed(pedArray[i].pedModel, pedArray[i].pedX, pedArray[i].pedY, pedArray[i].pedZ, pedArray[i].pedRot);
    }
});

// HOTKEY CHAT AN/AUS

mp.keys.bind(0x21, false, function() {
    if (chatVisible) mp.gui.chat.show(true);
    else mp.gui.chat.show(false);
    chatVisible = !chatVisible;
});

// HOTKEY HUD AN/AUS
mp.keys.bind(0x22, false, function() {
    if (mp.gui.cursor.visible) return;

    mp.events.callRemote("server:hotkey:HUD");
});

function spawnPed(model, x, y, z, rotation) {
    mp.peds.new(mp.game.joaat(`${model}`), new mp.Vector3(x, y, z), rotation, (streamPed) => {
        streamPed.setAlpha(255);
    });
}

function canInteract() { return lastInteract + 1000 < Date.now(); }

mp.keys.bind(0x2E, false, function() {
    mp.events.callRemote("Server:Kick:Kick", "");
});

mp.keys.bind(0x2D, false, function() {
    mp.events.callRemote("Server:Kick:Kick", "");
});

mp.keys.bind(0x78, false, function() {
    mp.events.callRemote("Server:Kick:Kick", "");
});


mp.keys.bind(0xBC, false, function() {
    if (!canInteract || usingRepairKit || usingWestOrAidKit || mp.gui.cursor.visible) return;
    usingWestOrAidKit = true;
    lastInteract = Date.now();
    mp.players.local.freezePosition(true);
    mp.events.callRemote("Server:User:useFirstAidKit");
    setTimeout(() => {
        usingWestOrAidKit = false;
        mp.players.local.freezePosition(false);
    }, 3900);
});

mp.keys.bind(0xBE, false, function() {
    if (!canInteract || usingWestOrAidKit || usingRepairKit || mp.gui.cursor.visible) return;
    usingWestOrAidKit = true;
    lastInteract = Date.now();
    mp.players.local.freezePosition(true);
    mp.events.callRemote("Server:User:useVest");
    setTimeout(() => {
        usingWestOrAidKit = false;
        mp.players.local.freezePosition(false);
    }, 3900);
});

mp.keys.bind(0x72, false, function() {
    if (!canInteract || usingRepairKit || usingWestOrAidKit || mp.gui.cursor.visible) return;
    usingRepairKit = true;
    lastInteract = Date.now();
    //mp.players.local.freezePosition(true);
    mp.events.callRemote("Server:User:repairVehicle");
    setTimeout(() => {
        usingRepairKit = false;
        mp.players.local.freezePosition(false);
    }, 4000);
});

// HOTKEY H
mp.keys.bind(0x48, false, function() {
    if (mp.gui.cursor.visible) return;

    mp.events.callRemote("server:hotkey:H");
});

// HOTKEY M
mp.keys.bind(0x4D, false, function() {
    if (mp.gui.cursor.visible) return;
    
    mp.events.callRemote("server:hotkey:M");
});

mp.events.add("render", () => {
    if (mp.players.local.isSprinting()) mp.game.player.restoreStamina(100);
    if (mp.players.local.vehicle) {
        mp.game.audio.setRadioToStationName("OFF");
        mp.game.audio.setUserRadioControlEnabled(false);
    }
    mp.game.controls.disableControlAction(0, 243, true);
    mp.game.player.setHealthRechargeMultiplier(0.0);
});

var toggleMouse = false;
mp.keys.bind(0x77, true, () => {
    toggleMouse = !toggleMouse;
    mp.gui.cursor.show(toggleMouse, toggleMouse);
});

mp.nametags.enabled = false;