namespace myApp

// 创建定义所有灯光行为的界面
{
    public interface ILight
    {
        void SwitchOn();
        void SwitchOff();
        bool IsOn();
    }
}