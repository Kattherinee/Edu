using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stack_queue_list
{
    public enum PriceRoundOption
    {
        X_95,
        X_99,
        X_00,
        X_X0,
        X_X5,
        X_X9
    }

    public class PriceRounder
    {
        public static void Test(PriceRoundOption option, bool up)
        {
            Console.WriteLine(option + " " + (up ? "UP" : "DOWN"));
            var subj = new PriceRounder { Up = up, Option = option };
            foreach (var d in new[]
                     {
                         0.00m, 0.01m, 0.02m, 0.03m, 0.04m, 0.05m, 0.06m, 0.07m, 0.08m, 0.09m, 0.10m,
                         0.11m, 0.90m, 0.94m, 0.95m, 0.96m, 0.97m, 0.98m, 0.99m, 1.00m, 1.01m
                     })
            {
                Console.WriteLine(d + "\t" + subj.Round(d));
            }

        }

        public PriceRoundOption Option { get; set; }
        public bool Up { get; set; }

        public decimal Round(decimal d)
        {
            decimal roundedValue = d;

            switch (Option)
            {
                case PriceRoundOption.X_95:
                    roundedValue = Up ? Math.Ceiling(d * 100 / 95) * 0.95m : Math.Floor(d * 100 / 95) * 0.95m;
                    break;
                case PriceRoundOption.X_99:
                    roundedValue = Up ? Math.Ceiling(d * 100 / 99) * 0.99m : Math.Floor(d * 100 / 99) * 0.99m;
                    break;
                case PriceRoundOption.X_00:
                    roundedValue = Up ? Math.Ceiling(d) : Math.Floor(d);
                    break;
                case PriceRoundOption.X_X0:
                    roundedValue = Up ? Math.Ceiling(d / 0.10m) * 0.10m : Math.Floor(d / 0.10m) * 0.10m;
                    break;
                case PriceRoundOption.X_X5:
                    roundedValue = Up ? Math.Ceiling(d / 0.05m) * 0.05m : Math.Floor(d / 0.05m) * 0.05m;
                    break;
                case PriceRoundOption.X_X9:
                    roundedValue = Up ? Math.Ceiling(d / 0.09m) * 0.09m : Math.Floor(d / 0.09m) * 0.09m;
                    break;

                default:
                    throw new ArgumentException("Invalid PriceRoundOption");

            }

            return roundedValue;
        }
    }

}
