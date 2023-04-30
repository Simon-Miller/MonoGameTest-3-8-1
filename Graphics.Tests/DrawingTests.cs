
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace Graphics.Tests
{
    [TestClass]
    public class DrawingTests
    {
        #region RectangleUnclipped

        // indirectly tests Drawing.HorizontalLineUnClipped
        [TestMethod]
        public void RectangleUnClipped_filled_1px()
        {
            // Arrange
            var bitmap = new UInt32[9]; // should fill with 0's.
            var canvas = new Drawing(bitmap, wide: 3, high: 3);

            // Act
            canvas.RectangleUnClipped(1, 1, 1, 1, 0x1); // filled

            // Assert
            Assert.IsTrue(IEnumerableComparer.DataEqual(bitmap, new UInt32[]
            {
                0,0,0,
                0,1,0,
                0,0,0
            }));
        }

        // indirectly tests Drawing.HorizontalLineUnClipped
        [TestMethod]
        public void RectangleUnClipped_filled_2px()
        {
            // Arrange
            var bitmap = new UInt32[16]; // should fill with 0's.
            var canvas = new Drawing(bitmap, wide: 4, high: 4);

            // Act
            canvas.RectangleUnClipped(1, 1, 2, 2, 0x1); // filled

            // Assert
            Assert.IsTrue(IEnumerableComparer.DataEqual(bitmap, new UInt32[]
            {
                0,0,0,0,
                0,1,1,0,
                0,1,1,0,
                0,0,0,0
            }));
        }

        // indirectly tests Drawing.HorizontalLineUnClipped
        [TestMethod]
        public void RectangleUnClipped_filled_3px()
        {
            // Arrange
            var bitmap = new UInt32[25]; // should fill with 0's.
            var canvas = new Drawing(bitmap, wide: 5, high: 5);

            // Act
            canvas.RectangleUnClipped(1, 1, 3, 3, 0x1); // filled

            // Assert
            Assert.IsTrue(IEnumerableComparer.DataEqual(bitmap, new UInt32[]
            {
                0,0,0,0,0,
                0,1,1,1,0,
                0,1,1,1,0,
                0,1,1,1,0,
                0,0,0,0,0
            }));
        }

        // indirectly tests Drawing.HorizontalLineUnClipped
        // indirectly tests Drawing.VerticalLineUnClipped
        [TestMethod]
        public void RectangleUnClipped_box_1px()
        {
            // Arrange
            var bitmap = new UInt32[9]; // should fill with 0's.
            var canvas = new Drawing(bitmap, wide: 3, high: 3);

            // Act
            canvas.RectangleUnClipped(1, 1, 1, 1, 0x1, fill: false);

            // Assert
            Assert.IsTrue(IEnumerableComparer.DataEqual(bitmap, new UInt32[]
            {
                0,0,0,
                0,1,0,
                0,0,0
            }));
        }

        // indirectly tests Drawing.HorizontalLineUnClipped
        // indirectly tests Drawing.VerticalLineUnClipped
        [TestMethod]
        public void RectangleUnClipped_box_2px()
        {
            // Arrange
            var bitmap = new UInt32[16]; // should fill with 0's.
            var canvas = new Drawing(bitmap, wide: 4, high: 4);

            // Act
            canvas.RectangleUnClipped(1, 1, 2, 2, 0x1, fill: false);

            // Assert
            Assert.IsTrue(IEnumerableComparer.DataEqual(bitmap, new UInt32[]
            {
                0,0,0,0,
                0,1,1,0,
                0,1,1,0,
                0,0,0,0
            }));
        }

        // indirectly tests Drawing.HorizontalLineUnClipped
        // indirectly tests Drawing.VerticalLineUnClipped
        [TestMethod]
        public void RectangleUnClipped_box_3px()
        {
            // Arrange
            var bitmap = new UInt32[25]; // should fill with 0's.
            var canvas = new Drawing(bitmap, wide: 5, high: 5);

            // Act
            canvas.RectangleUnClipped(1, 1, 3, 3, 0x1, fill: false);

            // Assert
            Assert.IsTrue(IEnumerableComparer.DataEqual(bitmap, new UInt32[]
            {
                0,0,0,0,0,
                0,1,1,1,0,
                0,1,0,1,0,
                0,1,1,1,0,
                0,0,0,0,0
            }));
        }

        [TestMethod]
        public void RectangleUnClipped_topLeftEdge_1px()
        {
            // Arrange
            var bitmap = new UInt32[9]; // should fill with 0's.
            var canvas = new Drawing(bitmap, wide: 3, high: 3);

            // Act
            canvas.RectangleUnClipped(0, 0, 1, 1, 0x1); // filled

            // Assert
            Assert.IsTrue(IEnumerableComparer.DataEqual(bitmap, new UInt32[]
            {
                1,0,0,
                0,0,0,
                0,0,0
            }));
        }

        [TestMethod]
        public void RectangleUnClipped_bottomRightEdge_1px()
        {
            // Arrange
            var bitmap = new UInt32[9]; // should fill with 0's.
            var canvas = new Drawing(bitmap, wide: 3, high: 3);

            // Act
            canvas.RectangleUnClipped(2, 2, 1, 1, 0x1); // filled

            // Assert
            Assert.IsTrue(IEnumerableComparer.DataEqual(bitmap, new UInt32[]
            {
                0,0,0,
                0,0,0,
                0,0,1
            }));
        }

        [TestMethod]
        public void RectangleUnClipped_box_topLeftEdge_1px()
        {
            // Arrange
            var bitmap = new UInt32[9]; // should fill with 0's.
            var canvas = new Drawing(bitmap, wide: 3, high: 3);

            // Act
            canvas.RectangleUnClipped(0, 0, 1, 1, 0x1, fill: false);

            // Assert
            Assert.IsTrue(IEnumerableComparer.DataEqual(bitmap, new UInt32[]
            {
                1,0,0,
                0,0,0,
                0,0,0
            }));
        }

        [TestMethod]
        public void RectangleUnClipped_box_bottomRightEdge_1px()
        {
            // Arrange
            var bitmap = new UInt32[9]; // should fill with 0's.
            var canvas = new Drawing(bitmap, wide: 3, high: 3);

            // Act
            canvas.RectangleUnClipped(2, 2, 1, 1, 0x1, fill: false);

            // Assert
            Assert.IsTrue(IEnumerableComparer.DataEqual(bitmap, new UInt32[]
            {
                0,0,0,
                0,0,0,
                0,0,1
            }));
        }

        #endregion

        #region HorizontalLine

        [TestMethod]
        public void HorizontalLine_1px()
        {
            // Arrange
            var bitmap = new UInt32[9]; // should fill with 0's.
            var canvas = new Drawing(bitmap, wide: 3, high: 3);

            // Act
            canvas.HorizontalLine(1, 1, width: 1, colour: 0x1);

            // Assert
            Assert.IsTrue(IEnumerableComparer.DataEqual(bitmap, new UInt32[]
            {
                0,0,0,
                0,1,0,
                0,0,0
            }));
        }

        [TestMethod]
        public void HorizontalLine_topLeft_2px()
        {
            // Arrange
            var bitmap = new UInt32[9]; // should fill with 0's.
            var canvas = new Drawing(bitmap, wide: 3, high: 3);

            // Act
            canvas.HorizontalLine(0, 0, width: 2, colour: 0x1);

            // Assert
            Assert.IsTrue(IEnumerableComparer.DataEqual(bitmap, new UInt32[]
            {
                1,1,0,
                0,0,0,
                0,0,0
            }));
        }

        [TestMethod]
        public void HorizontalLine_bottomRight_2px()
        {
            // Arrange
            var bitmap = new UInt32[9]; // should fill with 0's.
            var canvas = new Drawing(bitmap, wide: 3, high: 3);

            // Act
            canvas.HorizontalLine(1, 2, width: 2, colour: 0x1);

            // Assert
            Assert.IsTrue(IEnumerableComparer.DataEqual(bitmap, new UInt32[]
            {
                0,0,0,
                0,0,0,
                0,1,1
            }));
        }

        [TestMethod]
        public void HorizontalLine_clip_topRight_2px()
        {
            // Arrange
            var bitmap = new UInt32[9]; // should fill with 0's.
            var canvas = new Drawing(bitmap, wide: 3, high: 3);

            // Act
            canvas.HorizontalLine(2, 0, width: 2, colour: 0x1);

            // Assert
            Assert.IsTrue(IEnumerableComparer.DataEqual(bitmap, new UInt32[]
            {
                0,0,1,
                0,0,0,
                0,0,0
            }));
        }

        [TestMethod]
        public void HorizontalLine_clip_bottomRight_2px()
        {
            // Arrange
            var bitmap = new UInt32[9]; // should fill with 0's.
            var canvas = new Drawing(bitmap, wide: 3, high: 3);

            // Act
            canvas.HorizontalLine(2, 2, width: 2, colour: 0x1);

            // Assert
            Assert.IsTrue(IEnumerableComparer.DataEqual(bitmap, new UInt32[]
            {
                0,0,0,
                0,0,0,
                0,0,1
            }));
        }

        #endregion

        #region VerticalLine

        [TestMethod]
        public void VerticalLine_1px()
        {
            // Arrange
            var bitmap = new UInt32[9]; // should fill with 0's.
            var canvas = new Drawing(bitmap, wide: 3, high: 3);

            // Act
            canvas.VerticalLine(1, 1, height: 1, colour: 0x1);

            // Assert
            Assert.IsTrue(IEnumerableComparer.DataEqual(bitmap, new UInt32[]
            {
                0,0,0,
                0,1,0,
                0,0,0
            }));
        }

        [TestMethod]
        public void VerticalLine_topLeft_2px()
        {
            // Arrange
            var bitmap = new UInt32[9]; // should fill with 0's.
            var canvas = new Drawing(bitmap, wide: 3, high: 3);

            // Act
            canvas.VerticalLine(0, 0, height: 2, colour: 0x1);

            // Assert
            Assert.IsTrue(IEnumerableComparer.DataEqual(bitmap, new UInt32[]
            {
                1,0,0,
                1,0,0,
                0,0,0
            }));
        }

        [TestMethod]
        public void VerticalLine_bottomRight_2px()
        {
            // Arrange
            var bitmap = new UInt32[9]; // should fill with 0's.
            var canvas = new Drawing(bitmap, wide: 3, high: 3);

            // Act
            canvas.VerticalLine(2, 1, height: 2, colour: 0x1);

            // Assert
            Assert.IsTrue(IEnumerableComparer.DataEqual(bitmap, new UInt32[]
            {
                0,0,0,
                0,0,1,
                0,0,1
            }));
        }

        [TestMethod]
        public void VerticalLine_clip_bottomLeft_2px()
        {
            // Arrange
            var bitmap = new UInt32[9]; // should fill with 0's.
            var canvas = new Drawing(bitmap, wide: 3, high: 3);

            // Act
            canvas.VerticalLine(0, 2, height: 2, colour: 0x1);

            // Assert
            Assert.IsTrue(IEnumerableComparer.DataEqual(bitmap, new UInt32[]
            {
                0,0,0,
                0,0,0,
                1,0,0
            }));
        }

        [TestMethod]
        public void VerticalLine_clip_bottomRight_2px()
        {
            // Arrange
            var bitmap = new UInt32[9]; // should fill with 0's.
            var canvas = new Drawing(bitmap, wide: 3, high: 3);

            // Act
            canvas.VerticalLine(2, 2, height: 2, colour: 0x1);

            // Assert
            Assert.IsTrue(IEnumerableComparer.DataEqual(bitmap, new UInt32[]
            {
                0,0,0,
                0,0,0,
                0,0,1
            }));
        }

        #endregion

        #region Line

        [TestMethod]
        public void Line_2px_test1()
        {
            // Arrange
            var bitmap = new UInt32[9]; // should fill with 0's.
            var canvas = new Drawing(bitmap, wide: 3, high: 3);

            // Act
            canvas.Line(1, 1, x2: 0, y2: 0, colour: 0x1);

            // Assert
            Assert.IsTrue(IEnumerableComparer.DataEqual(bitmap, new UInt32[]
            {
                1,0,0,
                0,1,0,
                0,0,0
            }));
        }

        [TestMethod]
        public void Line_2px_test2()
        {
            // Arrange
            var bitmap = new UInt32[9]; // should fill with 0's.
            var canvas = new Drawing(bitmap, wide: 3, high: 3);

            // Act - BOOM!!!  Found an error to fix.
            canvas.Line(1, 1, x2: 1, y2: 0, colour: 0x1);

            // Assert
            Assert.IsTrue(IEnumerableComparer.DataEqual(bitmap, new UInt32[]
            {
                0,1,0,
                0,1,0,
                0,0,0
            }));
        }

        [TestMethod]
        public void Line_2px_test3()
        {
            // Arrange
            var bitmap = new UInt32[9]; // should fill with 0's.
            var canvas = new Drawing(bitmap, wide: 3, high: 3);

            // Act - BOOM! Didn't drop top-right pixel??
            // BOOM! drawn top left pixel instead of top-right?
            canvas.Line(1, 1, x2: 2, y2: 0, colour: 0x1);

            // Assert
            Assert.IsTrue(IEnumerableComparer.DataEqual(bitmap, new UInt32[]
            {
                0,0,1,
                0,1,0,
                0,0,0
            }));
        }

        [TestMethod]
        public void Line_2px_test4()
        {
            // Arrange
            var bitmap = new UInt32[9]; // should fill with 0's.
            var canvas = new Drawing(bitmap, wide: 3, high: 3);

            // Act
            canvas.Line(1, 1, x2: 2, y2: 1, colour: 0x1);

            // Assert
            Assert.IsTrue(IEnumerableComparer.DataEqual(bitmap, new UInt32[]
            {
                0,0,0,
                0,1,1,
                0,0,0
            }));
        }

        [TestMethod]
        public void Line_2px_test5()
        {
            // Arrange
            var bitmap = new UInt32[9]; // should fill with 0's.
            var canvas = new Drawing(bitmap, wide: 3, high: 3);

            // Act
            canvas.Line(1, 1, x2: 2, y2: 2, colour: 0x1);

            // Assert
            Assert.IsTrue(IEnumerableComparer.DataEqual(bitmap, new UInt32[]
            {
                0,0,0,
                0,1,0,
                0,0,1
            }));
        }

        [TestMethod]
        public void Line_2px_test6()
        {
            // Arrange
            var bitmap = new UInt32[9]; // should fill with 0's.
            var canvas = new Drawing(bitmap, wide: 3, high: 3);

            // Act
            canvas.Line(1, 1, x2: 1, y2: 2, colour: 0x1);

            // Assert
            Assert.IsTrue(IEnumerableComparer.DataEqual(bitmap, new UInt32[]
            {
                0,0,0,
                0,1,0,
                0,1,0
            }));
        }

        [TestMethod]
        public void Line_2px_test7()
        {
            // Arrange
            var bitmap = new UInt32[9]; // should fill with 0's.
            var canvas = new Drawing(bitmap, wide: 3, high: 3);

            // Act
            canvas.Line(1, 1, x2: 0, y2: 2, colour: 0x1);

            // Assert
            Assert.IsTrue(IEnumerableComparer.DataEqual(bitmap, new UInt32[]
            {
                0,0,0,
                0,1,0,
                1,0,0
            }));
        }

        [TestMethod]
        public void Line_2px_test8()
        {
            // Arrange
            var bitmap = new UInt32[9]; // should fill with 0's.
            var canvas = new Drawing(bitmap, wide: 3, high: 3);

            // Act
            canvas.Line(1, 1, x2: 0, y2: 1, colour: 0x1);

            // Assert
            Assert.IsTrue(IEnumerableComparer.DataEqual(bitmap, new UInt32[]
            {
                0,0,0,
                1,1,0,
                0,0,0
            }));
        }

        [TestMethod]
        public void Line_2px_test9()
        {
            // Arrange
            var bitmap = new UInt32[9]; // should fill with 0's.
            var canvas = new Drawing(bitmap, wide: 3, high: 3);

            // Act
            canvas.Line(1, 2, x2: 2, y2: 0, colour: 0x1);

            // Assert
            Assert.IsTrue(IEnumerableComparer.DataEqual(bitmap, new UInt32[]
            {
                0,0,1,
                0,0,1,
                0,1,0
            }));
        }

        [TestMethod]
        public void Line_2px_test10()
        {
            // Arrange
            var bitmap = new UInt32[16]; // should fill with 0's.
            var canvas = new Drawing(bitmap, wide: 4, high: 4);

            // Act
            canvas.Line(1, 3, x2: 2, y2: 0, colour: 0x1);

            // Assert
            Assert.IsTrue(IEnumerableComparer.DataEqual(bitmap, new UInt32[]
            {
                0,0,1,0,
                0,0,1,0,
                0,1,0,0,
                0,1,0,0
            }));
        }

        [TestMethod]
        public void Line_2px_test11()
        {
            // Arrange
            var bitmap = new UInt32[16]; // should fill with 0's.
            var canvas = new Drawing(bitmap, wide: 4, high: 4);

            // Act
            canvas.Line(1, 0, x2: 2, y2: 3, colour: 0x1);

            // Assert
            Assert.IsTrue(IEnumerableComparer.DataEqual(bitmap, new UInt32[]
            {
                0,1,0,0,
                0,1,0,0,
                0,0,1,0,
                0,0,1,0
            }));
        }

        [TestMethod]
        public void Line_special_direction1()
        {
            // Arrange
            var bitmap = new UInt32[16]; // should fill with 0's.
            var canvas = new Drawing(bitmap, wide: 4, high: 4);

            int x = 1, y = 2;

            // Act
            canvas.Line(ref x, ref y, direction: 1, length: 2, colour: 0x01);

            // Assert
            Assert.IsTrue(IEnumerableComparer.DataEqual(bitmap, new UInt32[]
            {
                0,1,0,0,
                0,1,0,0,
                0,0,0,0,
                0,0,0,0
            }));
        }

        [TestMethod]
        public void Line_special_direction2()
        {
            // Arrange
            var bitmap = new UInt32[16]; // should fill with 0's.
            var canvas = new Drawing(bitmap, wide: 4, high: 4);

            int x = 1, y = 2;

            // Act
            canvas.Line(ref x, ref y, direction: 2, length: 2, colour: 0x01);

            // Assert
            Assert.IsTrue(IEnumerableComparer.DataEqual(bitmap, new UInt32[]
            {
                0,0,0,1,
                0,0,1,0,
                0,0,0,0,
                0,0,0,0
            }));
        }

        [TestMethod]
        public void Line_special_direction3()
        {
            // Arrange
            var bitmap = new UInt32[16]; // should fill with 0's.
            var canvas = new Drawing(bitmap, wide: 4, high: 4);

            int x = 1, y = 2;

            // Act
            canvas.Line(ref x, ref y, direction: 3, length: 2, colour: 0x01);

            // Assert
            Assert.IsTrue(IEnumerableComparer.DataEqual(bitmap, new UInt32[]
            {
                0,0,0,0,
                0,0,0,0,
                0,0,1,1,
                0,0,0,0
            }));
        }

        [TestMethod]
        public void Line_special_direction4()
        {
            // Arrange
            var bitmap = new UInt32[16]; // should fill with 0's.
            var canvas = new Drawing(bitmap, wide: 4, high: 4);

            int x = 1, y = 1;

            // Act
            canvas.Line(ref x, ref y, direction: 4, length: 2, colour: 0x01);

            // Assert
            Assert.IsTrue(IEnumerableComparer.DataEqual(bitmap, new UInt32[]
            {
                0,0,0,0,
                0,0,0,0,
                0,0,1,0,
                0,0,0,1
            }));
        }

        [TestMethod]
        public void Line_special_direction5()
        {
            // Arrange
            var bitmap = new UInt32[16]; // should fill with 0's.
            var canvas = new Drawing(bitmap, wide: 4, high: 4);

            int x = 1, y = 1;

            // Act
            canvas.Line(ref x, ref y, direction: 5, length: 2, colour: 0x01);

            // Assert
            Assert.IsTrue(IEnumerableComparer.DataEqual(bitmap, new UInt32[]
            {
                0,0,0,0,
                0,0,0,0,
                0,1,0,0,
                0,1,0,0
            }));
        }

        [TestMethod]
        public void Line_special_direction6()
        {
            // Arrange
            var bitmap = new UInt32[16]; // should fill with 0's.
            var canvas = new Drawing(bitmap, wide: 4, high: 4);

            int x = 2, y = 1;

            // Act
            canvas.Line(ref x, ref y, direction: 6, length: 2, colour: 0x01);

            // Assert
            Assert.IsTrue(IEnumerableComparer.DataEqual(bitmap, new UInt32[]
            {
                0,0,0,0,
                0,0,0,0,
                0,1,0,0,
                1,0,0,0
            }));
        }

        [TestMethod]
        public void Line_special_direction7()
        {
            // Arrange
            var bitmap = new UInt32[16]; // should fill with 0's.
            var canvas = new Drawing(bitmap, wide: 4, high: 4);

            int x = 2, y = 1;

            // Act
            canvas.Line(ref x, ref y, direction: 7, length: 2, colour: 0x01);

            // Assert
            Assert.IsTrue(IEnumerableComparer.DataEqual(bitmap, new UInt32[]
            {
                0,0,0,0,
                1,1,0,0,
                0,0,0,0,
                0,0,0,0
            }));
        }

        [TestMethod]
        public void Line_special_direction8()
        {
            // Arrange
            var bitmap = new UInt32[16]; // should fill with 0's.
            var canvas = new Drawing(bitmap, wide: 4, high: 4);

            int x = 2, y = 2;

            // Act
            canvas.Line(ref x, ref y, direction: 8, length: 2, colour: 0x01);

            // Assert
            Assert.IsTrue(IEnumerableComparer.DataEqual(bitmap, new UInt32[]
            {
                1,0,0,0,
                0,1,0,0,
                0,0,0,0,
                0,0,0,0
            }));
        }

        #endregion

        #region Draw

        [TestMethod]
        public void Draw_u1()
        {
            commonDrawTest(canvas => canvas.Draw(2, 2, "u1", 0x01), new UInt32[]
            {
                0,0,0,0,
                0,0,1,0,
                0,0,1,0,
                0,0,0,0,
            });
        }

        [TestMethod]
        public void Draw_d1()
        {
            commonDrawTest(canvas => canvas.Draw(1, 1, "d1", 0x01), new UInt32[]
            {
                0,0,0,0,
                0,1,0,0,
                0,1,0,0,
                0,0,0,0,
            });
        }

        [TestMethod]
        public void Draw_l1()
        {
            commonDrawTest(canvas => canvas.Draw(2, 2, "l1", 0x01), new UInt32[]
            {
                0,0,0,0,
                0,0,0,0,
                0,1,1,0,
                0,0,0,0,
            });
        }

        [TestMethod]
        public void Draw_r1()
        {
            commonDrawTest(canvas => canvas.Draw(1, 1, "r1", 0x01), new UInt32[]
            {
                0,0,0,0,
                0,1,1,0,
                0,0,0,0,
                0,0,0,0,
            });
        }

        [TestMethod]
        public void Draw_e1()
        {
            commonDrawTest(canvas => canvas.Draw(1, 2, "e1", 0x01), new UInt32[]
            {
                0,0,0,0,
                0,0,1,0,
                0,1,0,0,
                0,0,0,0,
            });
        }

        [TestMethod]
        public void Draw_f1()
        {
            commonDrawTest(canvas => canvas.Draw(1, 1, "f1", 0x01), new UInt32[]
            {
                0,0,0,0,
                0,1,0,0,
                0,0,1,0,
                0,0,0,0,
            });
        }

        [TestMethod]
        public void Draw_g1()
        {
            commonDrawTest(canvas => canvas.Draw(2, 1, "g1", 0x01), new UInt32[]
            {
                0,0,0,0,
                0,0,1,0,
                0,1,0,0,
                0,0,0,0,
            });
        }

        [TestMethod]
        public void Draw_h1()
        {
            commonDrawTest(canvas => canvas.Draw(2, 2, "h1", 0x01), new UInt32[]
            {
                0,0,0,0,
                0,1,0,0,
                0,0,1,0,
                0,0,0,0,
            });
        }

        [TestMethod]
        public void Draw_u2()
        {
            commonDrawTest(canvas => canvas.Draw(2, 2, "u2", 0x01), new UInt32[]
            {
                0,0,1,0,
                0,0,1,0,
                0,0,1,0,
                0,0,0,0,
            });
        }

        [TestMethod]
        public void Draw_d2()
        {
            commonDrawTest(canvas => canvas.Draw(1, 1, "d2", 0x01), new UInt32[]
            {
                0,0,0,0,
                0,1,0,0,
                0,1,0,0,
                0,1,0,0,
            });
        }

        [TestMethod]
        public void Draw_l2()
        {
            commonDrawTest(canvas => canvas.Draw(2, 2, "l2", 0x01), new UInt32[]
            {
                0,0,0,0,
                0,0,0,0,
                1,1,1,0,
                0,0,0,0,
            });
        }

        [TestMethod]
        public void Draw_r2()
        {
            commonDrawTest(canvas => canvas.Draw(1, 1, "r2", 0x01), new UInt32[]
            {
                0,0,0,0,
                0,1,1,1,
                0,0,0,0,
                0,0,0,0,
            });
        }

        [TestMethod]
        public void Draw_e2()
        {
            commonDrawTest(canvas => canvas.Draw(1, 2, "e2", 0x01), new UInt32[]
            {
                0,0,0,1,
                0,0,1,0,
                0,1,0,0,
                0,0,0,0,
            });
        }

        [TestMethod]
        public void Draw_f2()
        {
            commonDrawTest(canvas => canvas.Draw(1, 1, "f2", 0x01), new UInt32[]
            {
                0,0,0,0,
                0,1,0,0,
                0,0,1,0,
                0,0,0,1,
            });
        }

        [TestMethod]
        public void Draw_g2()
        {
            commonDrawTest(canvas => canvas.Draw(2, 1, "g2", 0x01), new UInt32[]
            {
                0,0,0,0,
                0,0,1,0,
                0,1,0,0,
                1,0,0,0,
            });
        }

        [TestMethod]
        public void Draw_h2()
        {
            commonDrawTest(canvas => canvas.Draw(2, 2, "h2", 0x01), new UInt32[]
            {
                1,0,0,0,
                0,1,0,0,
                0,0,1,0,
                0,0,0,0,
            });
        }

        [TestMethod]
        public void Draw_u4()
        {
            // out of bounds, clipped.
            commonDrawTest(canvas => canvas.Draw(2, 2, "u4", 0x01), new UInt32[]
            {
                0,0,1,0,
                0,0,1,0,
                0,0,1,0,
                0,0,0,0,
            });
        }
        
        [TestMethod]
        public void Draw_d4()
        {
            // out of bounds, clipped.
            commonDrawTest(canvas => canvas.Draw(1, 1, "d4", 0x01), new UInt32[]
            {
                0,0,0,0,
                0,1,0,0,
                0,1,0,0,
                0,1,0,0,
            });
        }

        [TestMethod]
        public void Draw_l4()
        {
            // out of bounds, clipped.
            commonDrawTest(canvas => canvas.Draw(2, 2, "l4", 0x01), new UInt32[]
            {
                0,0,0,0,
                0,0,0,0,
                1,1,1,0,
                0,0,0,0,
            });
        }

        [TestMethod]
        public void Draw_e4()
        {
            // out of bounds, clipped.
            commonDrawTest(canvas => canvas.Draw(1, 2, "e4", 0x01), new UInt32[]
            {
                0,0,0,1,
                0,0,1,0,
                0,1,0,0,
                0,0,0,0,
            });
            // out of bounds, clipped.
            commonDrawTest(canvas => canvas.Draw(0, 2, "e4", 0x01), new UInt32[]
            {
                0,0,1,0,
                0,1,0,0,
                1,0,0,0,
                0,0,0,0,
            });
            // out of bounds, clipped.
            commonDrawTest(canvas => canvas.Draw(2, 3, "e4", 0x01), new UInt32[]
            {
                0,0,0,0,
                0,0,0,0,
                0,0,0,1,
                0,0,1,0,
            });
        }

        [TestMethod]
        public void Draw_f4()
        {
            // out of bounds, clipped.
            commonDrawTest(canvas => canvas.Draw(1, 1, "f4", 0x01), new UInt32[]
            {
                0,0,0,0,
                0,1,0,0,
                0,0,1,0,
                0,0,0,1,
            });
            // out of bounds, clipped.
            commonDrawTest(canvas => canvas.Draw(2, 0, "f4", 0x01), new UInt32[]
            {
                0,0,1,0,
                0,0,0,1,
                0,0,0,0,
                0,0,0,0,
            });
            // out of bounds, clipped.
            commonDrawTest(canvas => canvas.Draw(0, 2, "f4", 0x01), new UInt32[]
            {
                0,0,0,0,
                0,0,0,0,
                1,0,0,0,
                0,1,0,0,
            });
        }

        [TestMethod]
        public void Draw_g4()
        {
            // out of bounds, clipped.
            commonDrawTest(canvas => canvas.Draw(1, 0, "g4", 0x01), new UInt32[]
            {
                0,1,0,0,
                1,0,0,0,
                0,0,0,0,
                0,0,0,0,
            });
            // out of bounds, clipped.
            commonDrawTest(canvas => canvas.Draw(2, 1, "g4", 0x01), new UInt32[]
            {
                0,0,0,0,
                0,0,1,0,
                0,1,0,0,
                1,0,0,0,
            });
            // out of bounds, clipped.
            commonDrawTest(canvas => canvas.Draw(3, 2, "g4", 0x01), new UInt32[]
            {
                0,0,0,0,
                0,0,0,0,
                0,0,0,1,
                0,0,1,0,
            });
        }

        [TestMethod]
        public void Draw_h4()
        {
            // out of bounds, clipped.
            commonDrawTest(canvas => canvas.Draw(3, 1, "h4", 0x01), new UInt32[]
            {
                0,0,1,0,
                0,0,0,1,
                0,0,0,0,
                0,0,0,0,
            });
            // out of bounds, clipped.
            commonDrawTest(canvas => canvas.Draw(2, 2, "h4", 0x01), new UInt32[]
            {
                1,0,0,0,
                0,1,0,0,
                0,0,1,0,
                0,0,0,0,
            });
            // out of bounds, clipped.
            commonDrawTest(canvas => canvas.Draw(1, 3, "h4", 0x01), new UInt32[]
            {
                0,0,0,0,
                0,0,0,0,
                1,0,0,0,
                0,1,0,0,
            });
        }

        private void commonDrawTest(Action<Drawing> code, UInt32[] expectedResult)
        {
            // Arrange
            var bitmap = new UInt32[16]; // should fill with 0's.
            var canvas = new Drawing(bitmap, wide: 4, high: 4);

            // Act
            code(canvas);

            // Assert shurican-like shape
            Assert.IsTrue(IEnumerableComparer.DataEqual(bitmap, expectedResult));
        }

        [TestMethod]
        public void Draw_1()
        {
            // Arrange
            var bitmap = new UInt32[49]; // should fill with 0's.
            var canvas = new Drawing(bitmap, wide: 7, high: 7);

            // Act - BOOM!  needed to plot first pixel, then so movement calculations BEFORE rendering next pixel in each direction.
            canvas.Draw(1, 1, "r1d1u1e1r1f1d1l1r1f1d1g1l1u1d1g1l1h1u1r1l1h1u1", 0x01);

            // Assert shurican-like shape
            Assert.IsTrue(IEnumerableComparer.DataEqual(bitmap, new UInt32[]
            {
                0,0,0,1,1,0,0,
                0,1,1,0,0,1,0,
                1,0,1,0,1,1,0,
                1,0,0,0,0,0,1,
                0,1,1,0,1,0,1,
                0,1,0,0,1,1,0,
                0,0,1,1,0,0,0
            }));
        }

        [TestMethod]
        public void Draw_2()
        {
            // Arrange
            var bitmap = new UInt32[15]; // should fill with 0's.
            var canvas = new Drawing(bitmap, wide: 5, high: 3);

            // Act
            canvas.Draw(1, 1, "r2", 0x01);

            // Assert
            Assert.IsTrue(IEnumerableComparer.DataEqual(bitmap, new UInt32[]
            {
                0,0,0,0,0,
                0,1,1,1,0,
                0,0,0,0,0
            }));
        }

        #endregion

        #region Fill

        [TestMethod]
        public void Fill_inside()
        {
            // Arrange
            var bitmap = new UInt32[81]; // should fill with 0's.
            var canvas = new Drawing(bitmap, wide: 9, high: 9);

            /*
                         
                   ****  
                 ***  *  
                 * * *** 
                 *  x  *  // middle of this is staring point of fill.
                 *** * *  // Each fill direction from this point must also turn a corner.
                  *  *** 
                  ****   
                         
             */
            canvas.Draw(3, 3, "u2r3d2l1r2d3l2u1d2l3u2r1l2u3r1", colour: 0x01);

            var debug = canvas.debugHelper(bitmap, 9);

            // Act
            canvas.Fill(4, 4, colour: 0x01);

            debug = canvas.debugHelper(bitmap, 9);

            // Assert
            Assert.IsTrue(IEnumerableComparer.DataEqual(bitmap, new UInt32[]
            {
                0,0,0,0,0,0,0,0,0,
                0,0,0,1,1,1,1,0,0,
                0,1,1,1,1,1,1,0,0,
                0,1,1,1,1,1,1,1,0,
                0,1,1,1,1,1,1,1,0, // middle of this is staring point of fill.
                0,1,1,1,1,1,1,1,0,
                0,0,1,1,1,1,1,1,0,
                0,0,1,1,1,1,0,0,0,
                0,0,0,0,0,0,0,0,0
            }));
        }

        #endregion

        #region Circle

        [TestMethod]
        public void Circle_test1()
        {
            // Arrange
            var bitmap = new UInt32[81]; // should fill with 0's.
            var canvas = new Drawing(bitmap, wide: 9, high: 9);

            // Act
            canvas.Circle(4, 4, radius: 0, colour: 0x01);

            var debug = canvas.debugHelper(bitmap, wide: 9);

            // Assert
            Assert.IsTrue(IEnumerableComparer.DataEqual(bitmap, new UInt32[]
            {
                0,0,0,0,0,0,0,0,0,
                0,0,0,0,0,0,0,0,0,
                0,0,0,0,0,0,0,0,0,
                0,0,0,0,0,0,0,0,0,
                0,0,0,0,1,0,0,0,0,
                0,0,0,0,0,0,0,0,0,
                0,0,0,0,0,0,0,0,0,
                0,0,0,0,0,0,0,0,0,
                0,0,0,0,0,0,0,0,0
            }));
        }

        [TestMethod]
        public void Circle_test2()
        {
            // Arrange
            var bitmap = new UInt32[81]; // should fill with 0's.
            var canvas = new Drawing(bitmap, wide: 9, high: 9);

            // Act
            canvas.Circle(4, 4, radius: 1, colour: 0x01);

            var debug = canvas.debugHelper(bitmap, wide: 9);

            // Assert
            Assert.IsTrue(IEnumerableComparer.DataEqual(bitmap, new UInt32[]
            {
                0,0,0,0,0,0,0,0,0,
                0,0,0,0,0,0,0,0,0,
                0,0,0,0,0,0,0,0,0,
                0,0,0,0,1,0,0,0,0,
                0,0,0,1,0,1,0,0,0,
                0,0,0,0,1,0,0,0,0,
                0,0,0,0,0,0,0,0,0,
                0,0,0,0,0,0,0,0,0,
                0,0,0,0,0,0,0,0,0
            }));
        }

        [TestMethod]
        public void Circle_test3()
        {
            // Arrange
            var bitmap = new UInt32[81]; // should fill with 0's.
            var canvas = new Drawing(bitmap, wide: 9, high: 9);

            // Act
            canvas.Circle(4, 4, radius: 2, colour: 0x01);

            var debug = canvas.debugHelper(bitmap, wide: 9);

            // Assert
            Assert.IsTrue(IEnumerableComparer.DataEqual(bitmap, new UInt32[]
            {
                0,0,0,0,0,0,0,0,0,
                0,0,0,0,0,0,0,0,0,
                0,0,0,1,1,1,0,0,0,
                0,0,1,0,0,0,1,0,0,
                0,0,1,0,0,0,1,0,0,
                0,0,1,0,0,0,1,0,0,
                0,0,0,1,1,1,0,0,0,
                0,0,0,0,0,0,0,0,0,
                0,0,0,0,0,0,0,0,0
            }));
        }

        [TestMethod]
        public void Circle_test4()
        {
            // Arrange
            var bitmap = new UInt32[81]; // should fill with 0's.
            var canvas = new Drawing(bitmap, wide: 9, high: 9);

            // Act
            canvas.Circle(4, 4, radius: 3, colour: 0x01);

            var debug = canvas.debugHelper(bitmap, wide: 9);

            // Assert
            Assert.IsTrue(IEnumerableComparer.DataEqual(bitmap, new UInt32[]
            {
                0,0,0,0,0,0,0,0,0,
                0,0,0,1,1,1,0,0,0,
                0,0,1,0,0,0,1,0,0,
                0,1,0,0,0,0,0,1,0,
                0,1,0,0,0,0,0,1,0,
                0,1,0,0,0,0,0,1,0,
                0,0,1,0,0,0,1,0,0,
                0,0,0,1,1,1,0,0,0,
                0,0,0,0,0,0,0,0,0
            }));
        }

        [TestMethod]
        public void Circle_test5()
        {
            // Arrange
            var bitmap = new UInt32[81]; // should fill with 0's.
            var canvas = new Drawing(bitmap, wide: 9, high: 9);

            // Act
            canvas.Circle(4, 4, radius: 4, colour: 0x01);

            var debug = canvas.debugHelper(bitmap, wide: 9);

            // Assert
            Assert.IsTrue(IEnumerableComparer.DataEqual(bitmap, new UInt32[]
            {
                0,0,0,1,1,1,0,0,0,
                0,1,1,0,0,0,1,1,0,
                0,1,0,0,0,0,0,1,0,
                1,0,0,0,0,0,0,0,1,
                1,0,0,0,0,0,0,0,1,
                1,0,0,0,0,0,0,0,1,
                0,1,0,0,0,0,0,1,0,
                0,1,1,0,0,0,1,1,0,
                0,0,0,1,1,1,0,0,0
            }));
        }

        #endregion
    }
}