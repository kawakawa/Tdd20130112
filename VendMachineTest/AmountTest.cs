using VendMacnhine;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace VendMachineTest
{
    
    
    /// <summary>
    ///AmountTest のテスト クラスです。すべての
    ///AmountTest 単体テストをここに含めます
    ///</summary>
    [TestClass()]
    public class AmountTest
    {
        #region 追加のテスト属性
        // 
        //テストを作成するときに、次の追加属性を使用することができます:
        //
        //クラスの最初のテストを実行する前にコードを実行するには、ClassInitialize を使用
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //クラスのすべてのテストを実行した後にコードを実行するには、ClassCleanup を使用
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //各テストを実行する前にコードを実行するには、TestInitialize を使用
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //各テストを実行した後にコードを実行するには、TestCleanup を使用
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion

        VendMAchine target = new VendMAchine(); // TODO: 適切な値に初期化してください
        List<int> amountMoney = new List<int> { 10, 50, 100, 500, 1000 };
        List<int> ngAmountMoney = new List<int> { 1, 5, 2000, 5000, 10000 };


        /// <summary>
        ///GetTotal のテスト
        ///</summary>
        [TestMethod()]
        public void GetTotalTest()
        {
            int expected = 0; // TODO: 適切な値に初期化してください
            int actual;
            actual = target.GetTotal();
            Assert.AreEqual(expected, actual);
            //Assert.Inconclusive("このテストメソッドの正確性を確認します。");
        }

        [TestMethod()]
        public void お金を投入できる()
        {

            foreach (var n in amountMoney)
            {
                bool expected = true; // TODO: 適切な値に初期化してください
                bool actual;
                actual = target.Insert(n);
                Assert.AreEqual(expected, actual);
            }
            //Assert.Inconclusive("このテストメソッドの正確性を確認します。");
        }


        /// <summary>
        ///Insert のテスト
        ///</summary>
        [TestMethod()]
        public void お金を投入したら投入金額の合計が取得できる()
        {

            int expected = 0;

            foreach (var n in amountMoney)
            {

                target.Insert(n);

                expected += n;

            }

            int actualAmount = target.GetTotal();
            Assert.AreEqual(expected, actualAmount);

        }




        /// <summary>
        ///PayBack のテスト
        ///</summary>
        [TestMethod()]
        public void 投入せずに払い戻し処理をすると0円が戻る()
        {
            int expected = 0; // TODO: 適切な値に初期化してください
            int actual;
            target.PayBack();
            actual = target.Change;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void 払い戻し処理をすると投入した金額が戻る()
        {           
            foreach (var n in amountMoney)
            {
                int expected = n;
                target.Insert(n);
                int actual;
                target.PayBack();
                actual = target.Change;
                Assert.AreEqual(expected, actual);
            }
        }

        [TestMethod()]
        public void 払い戻し処理をすると投入した投入総額が戻る()
        {
            int expected = 0;
            foreach (var n in amountMoney)
            {
                target.Insert(n);
                expected += n;
            }
            int actual;
            target.PayBack();
            actual = target.Change;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void 払い戻し処理をすると投入金額が0円になる()
        {
            foreach (var n in amountMoney)
            {
                target.Insert(n);
            }
            target.PayBack();

            int expected = 0;
            int actual;
            actual = target.GetTotal();
            Assert.AreEqual(expected, actual);


        }

        

        [TestMethod()]
        public void 想定外の金額を投入しても投入金額が変わらない()
        {

            foreach (var n in ngAmountMoney)
            {
                target.Insert(n);

                int expected = 0;

                int actual;
                actual = target.GetTotal();
                Assert.AreEqual(expected, actual);

            }

        }



        

        [TestMethod()]
        public void 想定外の金額を投入するとつり銭に想定外の該当金額が返る()
        {
            foreach (var n in ngAmountMoney)
            {
                target.Insert(n);
                int expected = n;

                int actual;
                actual = target.Change;

                Assert.AreEqual(expected, actual);
            }



        }



    }
}
