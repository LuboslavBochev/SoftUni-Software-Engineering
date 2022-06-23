using OnlineShop.Common.Constants;
using OnlineShop.Models.Products.Components;
using OnlineShop.Models.Products.Computers;
using OnlineShop.Models.Products.Peripherals;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShop.Core
{
    public class Controller : IController
    {
        private readonly List<IComputer> computers;
        private readonly List<IComponent> components;
        private readonly List<IPeripheral> peripherals;

        public Controller()
        {
            this.computers = new List<IComputer>();
            this.components = new List<IComponent>();
            this.peripherals = new List<IPeripheral>();
        }

        public string AddComponent(int computerId, int id, string componentType, string manufacturer, string model, decimal price, double overallPerformance, int generation)
        { // ok
            if(!isExistComputer(computerId))
            {
                throw new ArgumentException(ExceptionMessages.NotExistingComputerId);
            }
            if(this.components.Exists(c => c.Id == id))
            {
                throw new ArgumentException(ExceptionMessages.ExistingComponentId);
            }

            IComponent component;

            switch(componentType)
            {
                case "CentralProcessingUnit":
                    component = new CentralProcessingUnit(id, manufacturer, model, price, overallPerformance, generation);
                    break;
                case "Motherboard":
                    component = new Motherboard(id, manufacturer, model, price, overallPerformance, generation);
                    break;
                case "PowerSupply":
                    component = new PowerSupply(id, manufacturer, model, price, overallPerformance, generation);
                    break;
                case "RandomAccessMemory":
                    component = new RandomAccessMemory(id, manufacturer, model, price, overallPerformance, generation);
                    break;
                case "SolidStateDrive":
                    component = new SolidStateDrive(id, manufacturer, model, price, overallPerformance, generation);
                    break;
                case "VideoCard":
                    component = new VideoCard(id, manufacturer, model, price, overallPerformance, generation);
                    break;

                default:
                    throw new ArgumentException(ExceptionMessages.InvalidComponentType);
            }

            IComputer computer = this.computers.Find(c => c.Id == computerId);
            computer.AddComponent(component);
            this.components.Add(component);

            return string.Format(SuccessMessages.AddedComponent, componentType, id, computerId);
        }

        public string AddComputer(string computerType, int id, string manufacturer, string model, decimal price) // ok
        {
            if(isExistComputer(id))
            {
                throw new ArgumentException(ExceptionMessages.ExistingComputerId);
            }

            IComputer computer;

            switch (computerType)
            {
                case "Laptop":

                    computer = new Laptop(id, manufacturer, model, price);
                    break;

                case "DesktopComputer":

                    computer = new DesktopComputer(id, manufacturer, model, price);
                    break;

                default:
                    throw new ArgumentException(ExceptionMessages.InvalidComputerType);
            }
            this.computers.Add(computer);
            return string.Format(SuccessMessages.AddedComputer, id);
        }

        public string AddPeripheral(int computerId, int id, string peripheralType, string manufacturer, string model, decimal price, double overallPerformance, string connectionType)
        {// ok
            if (!isExistComputer(computerId))
            {
                throw new ArgumentException(ExceptionMessages.NotExistingComputerId);
            }

            if (this.peripherals.Exists(c => c.Id == id))
            {
                throw new ArgumentException(ExceptionMessages.ExistingPeripheralId);
            }

            IPeripheral peripheral;

            switch (peripheralType)
            {
                case "Headset":
                    peripheral = new Headset(id, manufacturer, model, price, overallPerformance, connectionType);
                    break;
                case "Keyboard":
                    peripheral = new Keyboard(id, manufacturer, model, price, overallPerformance, connectionType);
                    break;
                case "Monitor":
                    peripheral = new Monitor(id, manufacturer, model, price, overallPerformance, connectionType);
                    break;
                case "Mouse":
                    peripheral = new Mouse(id, manufacturer, model, price, overallPerformance, connectionType);
                    break;

                default:
                    throw new ArgumentException(ExceptionMessages.InvalidPeripheralType);
            }
            IComputer computer = this.computers.Find(c => c.Id == computerId);
            computer.AddPeripheral(peripheral);
            this.peripherals.Add(peripheral);

            return string.Format(SuccessMessages.AddedPeripheral, peripheralType, id, computer.Id);
        }

        public string BuyBest(decimal budget) // ok
        {
            decimal minBudget = this.computers.Min(x => x.Price);

            IComputer boughtComputer = this.computers.OrderByDescending(c => c.OverallPerformance).ThenBy(c => c.Price <= budget).First();

            if (this.computers.Count == 0 || budget < minBudget) throw new ArgumentException(string.Format(ExceptionMessages.CanNotBuyComputer, budget));

            this.computers.Remove(boughtComputer);

            return boughtComputer.ToString();
        }

        public string BuyComputer(int id) // ok
        {
            if (!isExistComputer(id))
            {
                throw new ArgumentException(ExceptionMessages.NotExistingComputerId);
            }
            IComputer computer = this.computers.Find(c => c.Id == id);
            this.computers.Remove(computer);

            return computer.ToString();
        }

        public string GetComputerData(int id)
        {
            if (!isExistComputer(id))
            {
                throw new ArgumentException(ExceptionMessages.NotExistingComputerId);
            }

            return this.computers.Find(c => c.Id == id).ToString();
        }

        public string RemoveComponent(string componentType, int computerId) // ok
        {
            if (!isExistComputer(computerId))
            {
                throw new ArgumentException(ExceptionMessages.NotExistingComputerId);
            }

            IComputer computer = this.computers.Find(c => c.Id == computerId);

            IComponent component = computer.RemoveComponent(componentType);
            this.components.Remove(component);

            return string.Format(SuccessMessages.RemovedComponent, componentType, component.Id);
        }

        public string RemovePeripheral(string peripheralType, int computerId) // ok
        {
            if (!isExistComputer(computerId))
            {
                throw new ArgumentException(ExceptionMessages.NotExistingComputerId);
            }

            IComputer computer = this.computers.Find(c => c.Id == computerId);

            IPeripheral peripheral = computer.RemovePeripheral(peripheralType);
            this.peripherals.Remove(peripheral);

            return string.Format(SuccessMessages.RemovedPeripheral, peripheralType, peripheral.Id);
        }

        private bool isExistComputer(int computerId)
        {
            return this.computers.Exists(c => c.Id == computerId);
        }
    }
}
