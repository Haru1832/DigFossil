using System;
 
//下記参照
//https://hacchi-man.hatenablog.com/entry/2021/01/09/220000
public class SubscribeValue<T>
{
    public event Action<T> Subscribe;
    private T _value;
 
    public SubscribeValue()
    {
        _value = default;
    }
 
    public SubscribeValue(T defaultValue)
    {
        _value = defaultValue;
    }
 
    public T Value
    {
        get => _value;
        set
        {
            _value = value;
            Subscribe?.Invoke(_value);
        }
    }
}
