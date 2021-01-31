using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Calculator;

namespace Calculator.UnitTests
{
    [TestClass]
    public class ViewModelTests
    {
        #region Addition

        [TestMethod]
        public void Addition_Returns13()
        {
            var vm = new ViewModel();
            vm.NumBtnClick("5");
            vm.OperationBtnClick("+");
            vm.NumBtnClick("8");
            vm.EqualBtnClick("=");
            Assert.AreEqual("13", vm.TextResult);
        }
        [TestMethod]
        public void Addition_high_Returns13()
        {
            var vm = new ViewModel();
            vm.NumBtnClick("5");
            vm.OperationBtnClick("+");
            vm.NumBtnClick("3");
            vm.OperationBtnClick("+");
            vm.NumBtnClick("5");
            vm.EqualBtnClick("=");
            Assert.AreEqual("13", vm.TextResult);
        }
        [TestMethod]
        public void Addition_plusEqual_Returns8()
        {
            var vm = new ViewModel();
            vm.NumBtnClick("2");
            vm.OperationBtnClick("+");
            vm.NumBtnClick("3");
            vm.EqualBtnClick("=");
            vm.EqualBtnClick("=");
            Assert.AreEqual("8", vm.TextResult);
        }
        [TestMethod]
        public void Addition_plusEqualHigh_Returns8()
        {
            var vm = new ViewModel();
            vm.NumBtnClick("2");
            vm.OperationBtnClick("+");
            vm.NumBtnClick("3");
            vm.OperationBtnClick("+");
            vm.NumBtnClick("7");
            vm.EqualBtnClick("=");
            vm.EqualBtnClick("=");
            Assert.AreEqual("19", vm.TextResult);
        }
        #endregion
        #region Subtraction
        [TestMethod]
        public void Subtraction_ReturnsNegative3()
        {
            var vm = new ViewModel();
            vm.NumBtnClick("5");
            vm.OperationBtnClick("-");
            vm.NumBtnClick("8");
            vm.EqualBtnClick("=");
            Assert.AreEqual("-3", vm.TextResult);
        }
        [TestMethod]
        public void Subtraction_high_ReturnsNegative3()
        {
            var vm = new ViewModel();
            vm.NumBtnClick("5");
            vm.OperationBtnClick("-");
            vm.NumBtnClick("3");
            vm.OperationBtnClick("-");
            vm.NumBtnClick("5");
            vm.EqualBtnClick("=");
            Assert.AreEqual("-3", vm.TextResult);
        }
        [TestMethod]
        public void Subtraction_minusEqual_ReturnsNegative4()
        {
            var vm = new ViewModel();
            vm.NumBtnClick("2");
            vm.OperationBtnClick("-");
            vm.NumBtnClick("3");
            vm.EqualBtnClick("=");
            vm.EqualBtnClick("=");
            Assert.AreEqual("-4", vm.TextResult);
        }
        [TestMethod]
        public void Subtraction_minusEqualHigh_ReturnsNegative15()
        {
            var vm = new ViewModel();
            vm.NumBtnClick("2");
            vm.OperationBtnClick("-");
            vm.NumBtnClick("3");
            vm.OperationBtnClick("-");
            vm.NumBtnClick("7");
            vm.EqualBtnClick("=");
            vm.EqualBtnClick("=");
            Assert.AreEqual("-15", vm.TextResult);
        }
        #endregion
        #region Multiplication
        [TestMethod]
        public void Multiplication_Returns40()
        {
            var vm = new ViewModel();
            vm.NumBtnClick("5");
            vm.OperationBtnClick("*");
            vm.NumBtnClick("8");
            vm.EqualBtnClick("=");
            Assert.AreEqual("40", vm.TextResult);
        }
        [TestMethod]
        public void Multiplication_high_Returns75()
        {
            var vm = new ViewModel();
            vm.NumBtnClick("5");
            vm.OperationBtnClick("*");
            vm.NumBtnClick("3");
            vm.OperationBtnClick("*");
            vm.NumBtnClick("5");
            vm.EqualBtnClick("=");
            Assert.AreEqual("75", vm.TextResult);
        }
        [TestMethod]
        public void Multiplication_multEqual_Returns18()
        {
            var vm = new ViewModel();
            vm.NumBtnClick("2");
            vm.OperationBtnClick("*");
            vm.NumBtnClick("3");
            vm.EqualBtnClick("=");
            vm.EqualBtnClick("=");
            Assert.AreEqual("18", vm.TextResult);
        }
        [TestMethod]
        public void Multiplication_multEqualHigh_Returns294()
        {
            var vm = new ViewModel();
            vm.NumBtnClick("2");
            vm.OperationBtnClick("*");
            vm.NumBtnClick("3");
            vm.OperationBtnClick("*");
            vm.NumBtnClick("7");
            vm.EqualBtnClick("=");
            vm.EqualBtnClick("=");
            Assert.AreEqual("294", vm.TextResult);
        }
        #endregion
        #region Division
        [TestMethod]
        public void Division_ReturnsDot625()
        {
            var vm = new ViewModel();
            vm.NumBtnClick("5");
            vm.OperationBtnClick("/");
            vm.NumBtnClick("8");
            vm.EqualBtnClick("=");
            Assert.AreEqual("0,625", vm.TextResult);
        }
        [TestMethod]
        public void Division_high_Returns1()
        {
            var vm = new ViewModel();
            vm.NumBtnClick("5");
            vm.OperationBtnClick("/");
            vm.NumBtnClick("1");
            vm.OperationBtnClick("/");
            vm.NumBtnClick("5");
            vm.EqualBtnClick("=");
            Assert.AreEqual("1", vm.TextResult);
        }
        [TestMethod]
        public void Division_divEqual_ReturnsDot04()
        {
            var vm = new ViewModel();
            vm.NumBtnClick("1");
            vm.OperationBtnClick("/");
            vm.NumBtnClick("5");
            vm.EqualBtnClick("=");
            vm.EqualBtnClick("=");
            Assert.AreEqual("0,04", vm.TextResult);
        }
        [TestMethod]
        public void Division_divEqualHigh_ReturnsDot02()
        {
            var vm = new ViewModel();
            vm.NumBtnClick("1");
            vm.OperationBtnClick("/");
            vm.NumBtnClick("2");
            vm.OperationBtnClick("/");
            vm.NumBtnClick("5");
            vm.EqualBtnClick("=");
            vm.EqualBtnClick("=");
            Assert.AreEqual("0,02", vm.TextResult);
        }
        #endregion
        #region Clear
        [TestMethod]
        public void Clear_Returns0()
        {
            var vm = new ViewModel();
            vm.NumBtnClick("2");
            vm.ClearBtnClick("C");
            Assert.AreEqual("0", vm.TextResult);
        }
        #endregion
        #region ComplexTest
        [TestMethod]
        public void Complex_Returns40Dot25()
        {
            var vm = new ViewModel();
            vm.NumBtnClick("5");
            vm.OperationBtnClick("/");
            vm.NumBtnClick("8");
            vm.OperationBtnClick("*");
            vm.NumBtnClick("2");
            vm.OperationBtnClick("*");
            vm.OperationBtnClick("-");
            vm.NumBtnClick("5");
            vm.OperationBtnClick("+");
            vm.NumBtnClick("22");
            vm.EqualBtnClick("=");
            vm.EqualBtnClick("=");
            Assert.AreEqual("40,25", vm.TextResult);
        }
        #endregion
        #region Memory
        [TestMethod]
        public void MSMR_Returns22()
        {
            var vm = new ViewModel();
            vm.NumBtnClick("22");
            vm.MemorySave("MS");
            vm.ClearBtnClick("C");
            vm.NumBtnClick("123");
            vm.MemoryReturn("MR");
            Assert.AreEqual("22", vm.TextResult);
        }
        [TestMethod]
        public void MPlus_Returns25()
        {
            var vm = new ViewModel();
            vm.NumBtnClick("22");
            vm.MemorySave("MS");
            vm.ClearBtnClick("C");
            vm.NumBtnClick("3");
            vm.MemoryPlus("M+");
            vm.MemoryReturn("MR");
            Assert.AreEqual("25", vm.TextResult);
        }
        [TestMethod]
        public void MMinus_Returns19()
        {
            var vm = new ViewModel();
            vm.NumBtnClick("22");
            vm.MemorySave("MS");
            vm.ClearBtnClick("C");
            vm.NumBtnClick("3");
            vm.MemoryMinus("M-");
            vm.MemoryReturn("MR");
            Assert.AreEqual("19", vm.TextResult);
        }
        [TestMethod]
        public void MClear_Returns0()
        {
            var vm = new ViewModel();
            vm.NumBtnClick("22");
            vm.MemorySave("MS");
            vm.MemoryClear("MC");
            Assert.AreEqual(0, vm.MemoryList.Count);
        }
        #endregion
        #region HistoryList
        [TestMethod]
        public void HistoryListCount_Returns2()
        {
            var vm = new ViewModel();
            vm.NumBtnClick("22");
            vm.OperationBtnClick("+");
            vm.NumBtnClick("33");
            vm.EqualBtnClick("=");
            vm.EqualBtnClick("=");
            Assert.AreEqual(2, vm.HistoryList.Count);
        }
        #endregion
        #region ClearHistoryList
        [TestMethod]
        public void ClearHistoryList_Returns0()
        {
            var vm = new ViewModel();
            vm.NumBtnClick("33");
            vm.EqualBtnClick("=");
            vm.HistoryClearClick("ClearHistoryList");
            Assert.AreEqual(0, vm.HistoryList.Count);
        }
        #endregion
    }
}
