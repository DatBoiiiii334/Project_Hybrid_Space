namespace UnityEngine.PostProcessing
{
    public sealed class MinimalAttribute : PropertyAttribute
    {
        public readonly float min;

        public MinimalAttribute(float min)
        {
            this.min = min;
        }
    }
}
