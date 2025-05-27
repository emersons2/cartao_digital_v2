public class CardService
{
    public List<Card> GetCustomerCards(string documentNumber)
    {
        var customerService = new CustomerService();
        var customer = customerService.GetCustomers(documentNumber, null).FirstOrDefault();

        if (customer == null)
        {
            return [];
        }

        var cards = CardRepository.GetCards().Where(x => x.CustomerId == customer.CustomerId);

        return cards.ToList();
    }
}