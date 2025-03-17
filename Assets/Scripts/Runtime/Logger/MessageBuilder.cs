using System;
using UnityEngine;

namespace Runtime.Logger
{
    public class MessageBuilder
    {
        private readonly DSender _sender;
        
        private DFormat _format = DFormat.None;

        private string _text = string.Empty;
        private string _message = string.Empty;

        public MessageBuilder(DSender sender)
        {
            _sender = sender;
        }

        public MessageBuilder WithText(object message)
        {
            _text = message.ToString();
            _message = null;
            return this;
        }

        public MessageBuilder WithFormat(DFormat format)
        {
            _format = format;
            return this;
        }

        public void Log()
        {
            _message += _sender.Name + " " + _text;
            
            switch (_format)
            {
                case DFormat.None:
                    Debug.Log(_message);
                    break;
                
                case DFormat.Normal:
                    Debug.Log(_message);
                    break;

                case DFormat.Warning:
                    Debug.LogWarning(_message);
                    break;

                case DFormat.Error:
                    Debug.LogError(_message);
                    break;

                case DFormat.Exception:
                    Debug.LogException(new Exception(_message));
                    break;
                
                default:
                    Debug.Log(_message);
                    break;
            }
      
        }
    }
}