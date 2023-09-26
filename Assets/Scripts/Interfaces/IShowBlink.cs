using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IShowBlink 
{
    //Hiển thị blink sau khi đọc xong câu đầu tiên
    public void ShowBlinks(GameObject[] blinkGameObject, WordFilePaths wordFilePath,Page page);
}
