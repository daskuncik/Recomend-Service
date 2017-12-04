using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FLS.Rules;
using FLS.MembershipFunctions;
using FLS.Constants;
using FLS;

namespace RecomedProject.Classes
{
    class Month
    {
        public Income incomes;
        public Charge charges;
        //int month_id;
        //int year;
        string month_year;

        LinguisticVariable charge_percent;
        LinguisticVariable credit;
        LinguisticVariable food;
        LinguisticVariable can_charge;

        //charge_percent:
        IMembershipFunction good;
        IMembershipFunction bad;
        IMembershipFunction normal;

        //credit:
        IMembershipFunction give_earlier;
        IMembershipFunction give_after;
        IMembershipFunction give_intime;

        //food:
        IMembershipFunction much;
        IMembershipFunction normal_food;
        IMembershipFunction little;

        //can_charge
        IMembershipFunction more;
        IMembershipFunction norm;
        IMembershipFunction less;

        IFuzzyEngine fuzzyEngine_credit;
        IFuzzyEngine fuzzyEngine_can_charge_food;
        IFuzzyEngine fuzzyEngine_can_charge;

        //FuzzyRule rule1;
        FuzzyRule rule2;
        FuzzyRule rule3;
        FuzzyRule rule4;
        FuzzyRule rule5;
        FuzzyRule rule55;
        FuzzyRule rule56;
        FuzzyRule rule57;
        FuzzyRule rule58;
        FuzzyRule rule6;
        FuzzyRule rule7;
        FuzzyRule rule8;
        FuzzyRule rule9;
        FuzzyRule rule10;
        FuzzyRule rule11;
        FuzzyRule rule12;

        public Month(string name)
        {
            month_year = name;
            //month_id = moth;
            //year = year1;
            incomes = new Income();
            charges = new Charge();
            

            charge_percent = new LinguisticVariable("charge_percent"); //% расхода 
            credit = new LinguisticVariable("Credit"); //% дохода
            food = new LinguisticVariable("Food"); //% трат на еду вне дома
            can_charge = new LinguisticVariable("Can_charge");
            //charge_percent
            good = charge_percent.MembershipFunctions.AddTrapezoid("Good", 0, 10, 20, 45);
            bad = charge_percent.MembershipFunctions.AddTrapezoid("Bad", 60, 80, 90, 100); //% расходов от всех денег: 70%... - это плохо
            normal = charge_percent.MembershipFunctions.AddTrapezoid("Normal", 40, 50, 55, 68);
            //credit
            give_earlier = credit.MembershipFunctions.AddTrapezoid("Earlier", 65, 75, 87, 100); //% доходов больше 70, то можно отдать кредит раньше
            give_after = credit.MembershipFunctions.AddTrapezoid("After", 0, 20, 30, 45);
            give_intime = credit.MembershipFunctions.AddTrapezoid("InTime", 40, 50, 60, 65);
            //food
            much = food.MembershipFunctions.AddTrapezoid("Much", 65, 75, 85, 90);
            normal_food = food.MembershipFunctions.AddTrapezoid("Normal_food", 25, 55, 65, 70);
            little = food.MembershipFunctions.AddTrapezoid("Little", 0, 10, 20, 30);
            //can_charge
            more = can_charge.MembershipFunctions.AddTrapezoid("More", 65, 85, 100, 100);
            norm = can_charge.MembershipFunctions.AddTrapezoid("Norm", 40, 50, 60, 73);
            less = can_charge.MembershipFunctions.AddTrapezoid("Less", 0, 25, 40, 47);

            fuzzyEngine_credit = new FuzzyEngineFactory().Default();
            fuzzyEngine_can_charge = new FuzzyEngineFactory().Default();
            fuzzyEngine_can_charge_food = new FuzzyEngineFactory().Default();
            //rule1 = Rule.If(water.Is(cold).Or(water.Is(warm))).Then(power.Is(high));
            //rule1 = Rule.If(charge_percent.Is(bad)).Then(credit.Is(give_after));

            //ЕДА
            //если траты на еду норм и расходы малые или норм,то кредит можно отдать раньше
            rule2 = Rule.If(food.Is(normal_food).And(charge_percent.Is(good))).Then(credit.Is(give_earlier));
            //если траты на еду норм и расходы  норм,то кредит можно отдать вовремя
            rule3 = Rule.If(food.Is(normal_food).And(charge_percent.Is(normal))).Then(credit.Is(give_intime));
            //если на еду трат много и расходы большие, то кредит с опозданием
            rule4 = Rule.If(food.Is(much).And(charge_percent.Is(bad))).Then(credit.Is(give_after));
            //если трат мало и расходов мало, то кредит раньше
            rule5 = Rule.If(food.Is(little).And(charge_percent.Is(good))).Then(credit.Is(give_earlier));
            //если траты норма и на еду мало, то кредит раньше
            rule55 = Rule.If(food.Is(little).And(charge_percent.Is(normal))).Then(credit.Is(give_earlier));
            //если траты норм и еда много, то кредит вовремя
            rule56 = Rule.If(food.Is(normal_food).And(charge_percent.Is(normal))).Then(credit.Is(give_intime));
            //если траты много и еда норма, то кредит с опозданием
            rule57 = Rule.If(food.Is(normal_food).And(charge_percent.Is(bad))).Then(credit.Is(give_after));
            //если траты много и еда мало, то кредит вовремя
            rule58 = Rule.If(food.Is(little).And(charge_percent.Is(bad))).Then(credit.Is(give_intime));

            //РАСХОДЫ
            //если расходы маленьки, то тратить можно больше
            rule6 = Rule.If(charge_percent.Is(good)).Then(can_charge.Is(more));
            //если расходы большие, тратить нужно меньше.
            rule7 = Rule.If(charge_percent.Is(bad)).Then(can_charge.Is(less));
            //если расходы нормальные, расходы нормальные.
            rule8 = Rule.If(charge_percent.Is(normal)).Then(can_charge.Is(norm));

            //СКОЛЬКО МОЖНО ТРАТИТЬ
            //если расходы маленькие и на еду ВНЕ дома расходы маленькие, тратить можно больше
            rule9 = Rule.If(charge_percent.Is(good).And(food.Is(little))).Then(can_charge.Is(more));
            //если расходы большие и на еду ВНЕ дома расходы большие, тратить надо меньше
            rule10 = Rule.If(charge_percent.Is(bad).And(food.Is(much))).Then(can_charge.Is(less));
            //если расходы норм и на еду ВНЕ дома расходы большие, тратить надо меньше
            rule11 = Rule.If(charge_percent.Is(normal).And(food.Is(much))).Then(can_charge.Is(less));
            //если расходы норм и на еду норм, тратить надо норм
            rule12 = Rule.If(charge_percent.Is(normal).And(food.Is(normal_food))).Then(can_charge.Is(norm));

            fuzzyEngine_credit.Rules.Add(rule2, rule3, rule4, rule5, rule55, rule56, rule57, rule58);
            fuzzyEngine_can_charge.Rules.Add(rule6, rule7, rule8);
            fuzzyEngine_can_charge_food.Rules.Add(rule9, rule10, rule11, rule12);

            //double result = fuzzyEngine.Defuzzify(new { water = 60 });
        }

        public double getCanCharge()
        {
            int all_incomes = incomes.getAll();
            int all_charges = charges.getAll();
            int charge_percent1 = all_charges * 100 / (all_charges + all_incomes);
            return fuzzyEngine_can_charge.Defuzzify(new { charge_percent = charge_percent1 });
        }

        public double getCredit()
        {
            
            int all_incomes = incomes.getAll();
            int all_charges = charges.getAll();
            int food = charges.getGeneralFood();

            int charge_percent1 = all_charges * 100 / (all_charges + all_incomes);
            int food_percent1 = food * 100 / all_charges;
            return fuzzyEngine_credit.Defuzzify(new { charge_percent = charge_percent1, food = food_percent1 });
        }

        public void addForIncome(int position, int sum)
        {
            switch (position)
            {
                case 1:
                    incomes.addDebt(sum);
                    break;
                case 2:
                    incomes.addSalary(sum);
                    break;
                case 3:
                    incomes.addDividends(sum);
                    break;
                default:
                    break;
            }
        }

        public void addForCharges(int position, int sum)
        {
            switch (position)
            {
                case 1:
                    charges.addFood(sum);
                    break;
                case 2:
                    charges.addOutFood(sum);
                    break;
                case 3:
                    charges.addTransport(sum);
                    break;
                case 4:
                    charges.addCar(sum);
                    break;
                case 5:
                    charges.addShopping(sum);
                    break;
                case 6:
                    charges.addCommunals(sum);
                    break;
                case 7:
                    charges.addConnections(sum);
                    break;
                case 8:
                    charges.addCredit(sum);
                    break;
                default:
                    break;
            }
        }

        public string getMonthName()
        {
            return month_year;
        }

        
    }
}
