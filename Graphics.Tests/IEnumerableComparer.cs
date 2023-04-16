using System.Collections;

namespace Graphics.Tests
{
    internal static class IEnumerableComparer
    {
        public static bool DataEqual(IEnumerable left, IEnumerable right)
        {
            if (left is null && right is null) return true;
            if (left is null || right is null) return false;

            var leftEnumerator = left.GetEnumerator();
            var rightEnumerator = right.GetEnumerator();

            var rightHasMore = false;

            try
            {
                while (leftEnumerator.MoveNext())
                {
                    rightHasMore = rightEnumerator.MoveNext();

                    if (object.Equals(leftEnumerator.Current, rightEnumerator.Current) == false)
                        return false;
                }

                // when left final MoveNext, right doesn't get the chance to do the same, so need to here:
                rightHasMore = rightEnumerator.MoveNext();

                if (rightHasMore == false)
                    return true;

                return false;
            }
            catch
            {
                return false;
            }
        }
    }
}
