using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecomedProject.Classes
{
    public class Charge
    {
        List<int> food;
        List<int> outFood;
        List<int> transport;
        List<int> car;
        List<int> shopping;
        List<int> communals;
        List<int> connections;
        List<int> credit;

        public Charge()
        {
            food = new List<int>();
            outFood = new List<int>();
            transport = new List<int>();
            car = new List<int>();
            shopping = new List<int>();
            communals = new List<int>();
            connections = new List<int>();
            credit = new List<int>();
        }

        public void addFood(int price)
        {
            food.Add(price);
        }

        public void addOutFood(int price)
        {
            outFood.Add(price);
        }

        public void addTransport(int price)
        {
            transport.Add(price);
        }

        public void addCar(int price)
        {
            car.Add(price);
        }

        public void addShopping(int price)
        {
            shopping.Add(price);
        }

        public void addCommunals(int price)
        {
            communals.Add(price);
        }

        public void addConnections(int price)
        {
            connections.Add(price);
        }

        public void addCredit(int price)
        {
            credit.Add(price);
        }

        public int getGeneralFood()
        {
            int sum = 0;
            if (food.Count> 0)
                foreach (var elem in food)
                    sum += elem;
            return sum;
        }

        public int getGeneralOutFood()
        {
            int sum = 0;
            if (outFood.Count > 0)
                foreach (var elem in outFood)
                    sum += elem;
            return sum;
        }

        public int getGeneralTransport()
        {
            int sum = 0;
            if (transport.Count > 0)
                foreach (var elem in transport)
                    sum += elem;
            return sum;
        }

        public int getGeneralCar()
        {
            int sum = 0;
            if (car.Count > 0)
                foreach (var elem in car)
                    sum += elem;
            return sum;
        }

        public int getGeneralShopping()
        {
            int sum = 0;
            if (shopping.Count > 0)
                foreach (var elem in shopping)
                    sum += elem;
            return sum;
        }

        public int getGeneralCommunals()
        {
            int sum = 0;
            if (communals.Count > 0)
                foreach (var elem in communals)
                    sum += elem;
            return sum;
        }

        public int getGeneralConnections()
        {
            int sum = 0;
            if (connections.Count > 0)
                foreach (var elem in connections)
                    sum += elem;
            return sum;
        }

        public int getGeneralCredit()
        {
            int sum = 0;
            if (credit.Count > 0)
                foreach (var elem in credit)
                    sum += elem;
            return sum;
        }

        public int getAll()
        {
            int sum = 0;
            sum += getGeneralFood();
            sum += getGeneralOutFood();
            sum += getGeneralTransport();
            sum += getGeneralCar();
            sum += getGeneralShopping();
            sum += getGeneralCommunals();
            sum += getGeneralConnections();
            sum += getGeneralCredit();
            return sum;
        }
    }
}
