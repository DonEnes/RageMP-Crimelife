require ('./client/utils.js');
require('./cef/login/login.js');
require('./cef/HUD/hud.js');
require('./cef/Fraktionsauswahl/client.js');
require('./cef/FFA/Main.js');
require('./cef/Garage/Main.js');
require("./cef/notifications/index.js");
require("./cef/global-notifications/index.js");
require('./client/client.js');

require('sync.js');

require('weaponcomponents');






mp.discord.update('Gambo Gangwar','Gangwar');

mp.events.add('renderseat', () =>
{
	const controls = mp.game.controls;
	
	controls.enableControlAction(0, 23, true);
	controls.disableControlAction(0, 58, true);
	
	if(controls.isDisabledControlJustPressed(0, 58))
	{
		let position = mp.players.local.position;		
		let vehHandle = mp.game.vehicle.getClosestVehicle(position.x, position.y, position.z, 5, 0, 70);
		
		let vehicle = mp.vehicles.atHandle(vehHandle);
		
		if(vehicle
			&& vehicle.isAnySeatEmpty()
			&& vehicle.getSpeed() < 5)
		{
			mp.players.local.taskEnterVehicle(vehicle.handle, 5000, 0, 2, 1, 0);
		}
	}
});


mp.game.ped.setAiWeaponDamageModifier(1.025);
