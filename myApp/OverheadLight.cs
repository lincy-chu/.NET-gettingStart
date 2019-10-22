namespace myApp

// 头顶灯实现灯接口
{
    public class OverheadLight : ILight
    {
        private bool _isOn;
        public bool IsOn() => _isOn;
        public void SwitchOn() => _isOn = true;
        public void SwitchOff() => _isOn = false;
        public override string ToString() => $"The light is {(_isOn ? "On": "Off")}";

        public OverheadLight(bool isOn)
        {
            this._isOn = isOn;
        }
    }
}