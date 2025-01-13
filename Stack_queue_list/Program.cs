using System;
using Stack_queue_list;

public class Program
{
    public static void Main()
    {
        PriceRounder.Test(PriceRoundOption.X_95, true);
        PriceRounder.Test(PriceRoundOption.X_95, false);
        PriceRounder.Test(PriceRoundOption.X_99, true);
        PriceRounder.Test(PriceRoundOption.X_99, false);
        PriceRounder.Test(PriceRoundOption.X_00, true);
        PriceRounder.Test(PriceRoundOption.X_00, false);
        PriceRounder.Test(PriceRoundOption.X_X0, true);
        PriceRounder.Test(PriceRoundOption.X_X0, false);
        PriceRounder.Test(PriceRoundOption.X_X5, true);
        PriceRounder.Test(PriceRoundOption.X_X5, false);
        PriceRounder.Test(PriceRoundOption.X_X9, true);
        PriceRounder.Test(PriceRoundOption.X_X9, false);
    }
}
