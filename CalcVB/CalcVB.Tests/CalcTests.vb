Imports Microsoft.VisualStudio.TestTools.UnitTesting

Namespace CalcVB.Tests
    <TestClass>
    Public Class CalcTests
        <TestMethod>
        Sub Sum_a()

            Dim c As New Calc()

            Dim result = c.Sum(12, 4)

            Assert.AreEqual(16, result)

        End Sub

        <TestMethod>
        Sub Sum_MAX_ex()

            Dim c As New Calc()
            '   () => {} 

            'Sub ()

            'End Sub

            'function
            Assert.ThrowsException(Of OverflowException)(Sub() c.Sum(Int32.MaxValue, 1))



        End Sub
    End Class
End Namespace

