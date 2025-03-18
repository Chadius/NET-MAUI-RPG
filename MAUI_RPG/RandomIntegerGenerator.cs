using System.Globalization;

public interface IRandomIntegerGenerator {
    public Int32 Next(Int32 max);
}

public class RandomIntegerGenerator {
    Random rng;

    public RandomIntegerGenerator() {
        rng = new();
    }

    public Int32 Next(Int32 max) {
        return rng.Next(max);
    }
}