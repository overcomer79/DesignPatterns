using System;

namespace patterns
{

    public class Document
    {

    }

    public interface IPrinter
    {
        void Print(Document d);
    }

    public interface IScanner
    {
        void Scan(Document d);
    }

    public interface IFaxer
    {
        void Fax(Document d);
    }

    public interface IMultiFunctionDevice : IScanner, IPrinter, IFaxer
    {

    }

    public class Photocopier : IPrinter, IScanner
    {
        public void Print(Document d)
        {
            //
        }

        public void Scan(Document d)
        {
            //
        }
    }

    public class MultiFunctionMachine : IMultiFunctionDevice
    {
        private IPrinter printer;
        private IScanner scanner;
        private IFaxer faxer;

        public MultiFunctionMachine(IPrinter printer, IScanner scanner, IFaxer faxer)
        {
            this.printer = printer ?? throw new ArgumentNullException(paramName: nameof(printer));
            this.scanner = scanner ?? throw new ArgumentNullException(paramName: nameof(scanner));
            this.faxer = faxer ?? throw new ArgumentNullException(paramName: nameof(faxer));;
        }

        public void Fax(Document d)
        {
            faxer.Fax(d);
        }

        public void Print(Document d)
        {
            printer.Print(d);
        }

        public void Scan(Document d)
        {
            scanner.Scan(d);
        } // decorator pattern
    }

    class Program
    {
        static void Main(string[] args)
        {

        }
    }
}
