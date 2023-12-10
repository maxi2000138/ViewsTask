using UnityEngine;
using TMPro;

public class FPSCounter : MonoBehaviour
{
    public float updateInterval = 0.5f; // Интервал обновления FPS
    private float accum = 0; // Суммарное значение FPS за интервал
    private int frames = 0; // Количество кадров за интервал
    private float timeleft; // Оставшееся время до следующего обновления

    public TMP_Text fpsText; // Ссылка на компонент TMP_Text, куда будем выводить FPS

    void Start()
    {
        timeleft = updateInterval;
    }

    void Update()
    {
        timeleft -= Time.deltaTime;
        accum += Time.timeScale / Time.deltaTime;
        frames++;

        // Обновляем FPS каждый updateInterval секунд
        if (timeleft <= 0.0)
        {
            float fps = accum / frames;
            string fpsString = string.Format("{0:F2}", fps);

            // Выводим FPS в TMP_Text
            if (fpsText != null)
            {
                fpsText.text = fpsString;
            }

            // Сбрасываем счетчики
            timeleft = updateInterval;
            accum = 0;
            frames = 0;
        }
    }
}