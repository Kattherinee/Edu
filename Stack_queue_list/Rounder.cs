using System;

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
                Console.WriteLine($"{d:F2}\t{subj.Round(d):F2}");
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
                    decimal targetStep = 0.95m;

                    if (Up)
                    {
                        decimal roundedValueWithoutStep = Math.Ceiling(d * 20) / 20;
                        roundedValue = Math.Floor(roundedValueWithoutStep) + 0.95m;
                    }
                    else
                    {
                        if (d < targetStep)
                        {
                            roundedValue = 0.00m;
                        }
                        else
                        {
                            decimal divided = d / targetStep;
                            roundedValue = Math.Floor(divided) * targetStep;
                        }
                    }
                    break;

                case PriceRoundOption.X_99:
                    targetStep = 0.99m;

                    if (Up)
                    {
                        decimal roundedValueWithoutStep = Math.Ceiling(d * 100) / 100; 
                        roundedValue = Math.Floor(roundedValueWithoutStep) + 0.99m; 
                    }
                    else
                    {
                        if (d < 0.99m)
                        {
                            roundedValue = 0.00m; 
                        }
                        else
                        {
                            decimal divided = d / targetStep;
                            roundedValue = Math.Floor(divided) * targetStep;
                        }
                    }
                    break;

                case PriceRoundOption.X_00:
                    roundedValue = Up
                        ? Math.Ceiling(d)
                        : Math.Floor(d);
                    break;

                case PriceRoundOption.X_X0:
                    decimal baseValue = Math.Floor(d / 0.1m) * 0.1m;
                    if (Up)
                        roundedValue = d > baseValue ? baseValue + 0.1m : baseValue;
                    else
                        roundedValue = d < baseValue ? baseValue - 0.1m : baseValue;
                    break;

     
                case PriceRoundOption.X_X5:
                    if (Up)
                    {
                        if ((d * 10) % 1 == 0.5m)
                        {
                            roundedValue = d;
                        }
                        else
                        {
                            int desyatok = (int)(d * 10) % 10;
                            int sotaya = (int)(d * 100) % 10;

                            if (sotaya < 5)
                            {
                                roundedValue = (int)d + desyatok * 0.1m + 0.05m;
                            }
                            else
                            {
                                roundedValue = (int)d + (desyatok + 1) * 0.1m + 0.05m;
                            }
                        }
                    }
                    else 
                    {
                        if (d < 0.05m)
                        {
                            roundedValue = 0.00m;
                        }
                        else
                        {
                            if ((d * 10) % 1 == 0.5m)
                            {
                                roundedValue = d;
                            }
                            else
                            {
                                int desyatok = (int)(d * 10) % 10;
                                int sotaya = (int)(d * 100) % 10;

                                if (sotaya < 5)
                                {
                                    desyatok--;
                                    if (desyatok < 0)
                                    {
                                        roundedValue = (int)(d - 1) + 0.95m;
                                    }
                                    else
                                    {
                                        roundedValue = (int)d + desyatok * 0.1m + 0.05m;
                                    }
                                }
                                else
                                {
                                    roundedValue = (int)d + desyatok * 0.1m + 0.05m;
                                }
                            }
                        }
                    }
                    break;

                case PriceRoundOption.X_X9:
                    if (Up)
                    {
                        if ((d * 10) % 1 == 0.9m) 
                        {
                            roundedValue = d; 
                        }
                        else
                        {
                            int desyatok = (int)(d * 10) % 10;
                            roundedValue = (int)d + desyatok * 0.1m + 0.09m;
                            if (roundedValue <= d)
                            {
                                roundedValue += 0.1m;
                            }
                        }
                    }
                    else 
                    {
                        if (d < 0.09m)
                        {
                            roundedValue = 0.00m;
                        }
                        else
                        {
                            if ((d * 10) % 1 == 0.9m) 
                            {
                                roundedValue = d;
                            }
                            else
                            {
                                int desyatok = (int)(d * 10) % 10;
                                desyatok--;

                                if (desyatok < 0)
                                {
                                    roundedValue = (int)(d - 1) + 0.99m;
                                }
                                else
                                {
                                    roundedValue = (int)d + desyatok * 0.1m + 0.09m;
                                }
                            }
                        }
                    }
                    break;

                default:
                    throw new ArgumentException("Invalid PriceRoundOption");
            }

            return roundedValue;
        }
    }
}
