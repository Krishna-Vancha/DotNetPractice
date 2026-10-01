using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.C__Practise.DesignPatterns
{
    public class Adapter
    {
        public static void Main(string[] args) {
            ICashpayment payment = new PaymentAdaptor(new CardPayment());
            payment.PayAtCounter(); }
    }
    public interface ICashpayment
    {
        void PayAtCounter();
    }
    public class CardPayment
    {
        public void PayWithCard()
        {
            Console.WriteLine("Paid With Card");
        }
    }
    public class PaymentAdaptor : ICashpayment
    {

        public CardPayment payment;
        public PaymentAdaptor(CardPayment payment)
        {
            this.payment = payment;
        }

        public void PayAtCounter()
        {
            payment.PayWithCard();
        }
    }
}
