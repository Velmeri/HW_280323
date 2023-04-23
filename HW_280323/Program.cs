using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_280323
{
	internal class Program
	{
		static void Main(string[] args)
		{
			var factory = new MilitaryUnitFactory();

			var infantry1 = factory.GetUnit("Light Infantry");
			infantry1.Show("Base A");

			var infantry2 = factory.GetUnit("Light Infantry");
			infantry2.Show("Base B");

			var vehicle = factory.GetUnit("Transport Vehicle");
			vehicle.Show("Base C");

			var aircraft = factory.GetUnit("Aircraft");
			aircraft.Show("Airfield");

			Console.ReadKey(true);
		}
	}

	public interface IMilitaryUnit
	{
		void Show(string location);
	}

	public class LightInfantry : IMilitaryUnit
	{
		private readonly string _picture;
		private readonly int _speed;
		private readonly int _strength;

		public LightInfantry()
		{
			_picture = "Light Infantry";
			_speed = 20;
			_strength = 10;
		}

		public void Show(string location)
		{
			Console.WriteLine($"{_picture} unit is moving to {location} with speed {_speed} and strength {_strength}");
		}
	}

	public class TransportVehicle : IMilitaryUnit
	{
		private readonly string _picture;
		private readonly int _speed;
		private readonly int _strength;

		public TransportVehicle()
		{
			_picture = "Transport Vehicle";
			_speed = 70;
			_strength = 0;
		}

		public void Show(string location)
		{
			Console.WriteLine($"{_picture} is moving to {location} with speed {_speed} and strength {_strength}");
		}
	}

	public class HeavyGroundCombatEquipment : IMilitaryUnit
	{
		private readonly string _picture;
		private readonly int _speed;
		private readonly int _strength;

		public HeavyGroundCombatEquipment()
		{
			_picture = "Heavy Ground Combat Equipment";
			_speed = 15;
			_strength = 150;
		}

		public void Show(string location)
		{
			Console.WriteLine($"{_picture} is moving to {location} with speed {_speed} and strength {_strength}");
		}
	}

	public class LightGroundCombatEquipment : IMilitaryUnit
	{
		private readonly string _picture;
		private readonly int _speed;
		private readonly int _strength;

		public LightGroundCombatEquipment()
		{
			_picture = "Light Ground Combat Equipment";
			_speed = 50;
			_strength = 30;
		}

		public void Show(string location)
		{
			Console.WriteLine($"{_picture} is moving to {location} with speed {_speed} and strength {_strength}");
		}
	}

	public class Aircraft : IMilitaryUnit
	{
		private readonly string _picture;
		private readonly int _speed;
		private readonly int _strength;

		public Aircraft()
		{
			_picture = "Aircraft";
			_speed = 300;
			_strength = 100;
		}

		public void Show(string location)
		{
			Console.WriteLine($"{_picture} is flying to {location} with speed {_speed} and strength {_strength}");
		}
	}

	public class MilitaryUnitFactory
	{
		private readonly Dictionary<string, IMilitaryUnit> _units = new Dictionary<string, IMilitaryUnit>();

		public IMilitaryUnit GetUnit(string unitType)
		{
			if (!_units.ContainsKey(unitType)) {
				switch (unitType) {
					case "Light Infantry":
						_units[unitType] = new LightInfantry();
						break;
					case "Transport Vehicle":
						_units[unitType] = new TransportVehicle();
						break;
					case "Heavy Ground Combat Equipment":
						_units[unitType] = new HeavyGroundCombatEquipment();
						break;
					case "Light Ground Combat Equipment":
						_units[unitType] = new LightGroundCombatEquipment();
						break;
					case "Aircraft":
						_units[unitType] = new Aircraft();
						break;
					default:
						throw new ArgumentException($"Unknown unit type: {unitType}");
				}
			}

			return _units[unitType];
		}

	}
}