namespace BlazorAuto.Model
{
    public class CartService
    {
        private List<string> _products = new();

        public event EventHandler<CartEventArgs> CartChanged;

        public void AddToCart(string product)
        {
            _products.Add(product);
            CartChanged?.Invoke(this, new CartEventArgs());
        }

        public int GetProductCount(string product) => _products.Count(x => x == product);

        public int GetTotalCount() => _products.Count;
    }

    public class CartEventArgs
    {
    }

}
