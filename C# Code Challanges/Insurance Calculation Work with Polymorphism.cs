using System;

namespace InsuranceDetails //DO NOT Change namespace name
{
    public class Insurance
    {
        private string insuranceNo;
        private string insuranceName;
        private double amountCovered;

        public string InsuranceNo
        {
            get { return insuranceNo; }
            set { insuranceNo = value; }
        }

        public string InsuranceName
        {
            get { return insuranceName; }
            set { insuranceName = value; }
        }

        public double AmountCovered
        {
            get { return amountCovered; }
            set { amountCovered = value; }
        }
    }

    public class MotorInsurance : Insurance
    {
        private double idv;
        private float depPercent;

        public double Idv
        {
            get { return idv; }
            set { idv = value; }
        }

        public float DepPercent
        {
            get { return depPercent; }
            set { depPercent = value; }
        }

        public double calculatePremium()
        {
            Idv = AmountCovered - ((AmountCovered * DepPercent) / 100);
            return 0.03 * Idv;
        }
    }

    public class LifeInsurance : Insurance
    {
        private int policyTerm;
        private float benefitPercent;

        public int PolicyTerm
        {
            get { return policyTerm; }
            set { policyTerm = value; }
        }

        public float BenefitPercent
        {
            get { return benefitPercent; }
            set { benefitPercent = value; }
        }

        public double calculatePremium()
        {
            return (AmountCovered - ((AmountCovered * BenefitPercent) / 100)) / PolicyTerm;
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Insurance Number: ");
            string insuranceNo = Console.ReadLine();

            Console.WriteLine("Insurance Name: ");
            string insuranceName = Console.ReadLine();

            Console.WriteLine("Amount Covered: ");
            double amountCovered = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Select:\n1. Life Insurance\n2. Motor Insurance");
            int option = Convert.ToInt32(Console.ReadLine());

            Insurance insurance;

            if (option == 1)
            {
                Console.WriteLine("Policy Term: ");
                int policyTerm = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Benefit Percent: ");
                float benefitPercent = Convert.ToSingle(Console.ReadLine());

                insurance = new LifeInsurance
                {
                    InsuranceNo = insuranceNo,
                    InsuranceName = insuranceName,
                    AmountCovered = amountCovered,
                    PolicyTerm = policyTerm,
                    BenefitPercent = benefitPercent
                };
            }
            else if (option == 2)
            {
                Console.WriteLine("Depreciation Percent: ");
                float depPercent = Convert.ToSingle(Console.ReadLine());

                insurance = new MotorInsurance
                {
                    InsuranceNo = insuranceNo,
                    InsuranceName = insuranceName,
                    AmountCovered = amountCovered,
                    DepPercent = depPercent
                };
            }
            else
            {
                Console.WriteLine("Invalid option");
                return;
            }

            Program program = new Program();
            double premium = program.addPolicy(insurance, option);

            Console.WriteLine($"Calculated Premium: {premium}");
        }

        public double addPolicy(Insurance ins, int opt)
        {
            if (opt == 1)
            {
                LifeInsurance lifeInsurance = (LifeInsurance)ins;
                return lifeInsurance.calculatePremium();
            }
            else if (opt == 2)
            {
                MotorInsurance motorInsurance = (MotorInsurance)ins;
                return motorInsurance.calculatePremium();
            }
            else
            {
                throw new ArgumentException("Invalid option");
            }
        }
    }
}