[TOC]

## :man_firefighter: 화재 시뮬레이션 스크립트

### S#1. 지하철 안

(폭발)

안내창 : 열차에 화재가 발생했습니다. 주변 사람들에게 화재 발생을 알리세요.

“불이야”를 세 번 외쳐주세요

**STT : 불이야 불이야 불이야**

성공~!

### S#2. 지하철 안

안내창 : 지하철 뒤에 있는 비상 통화 장치를 통하여 기장에게 사실을 전달하세요

**STT : 차량 번호 7101번에서 화재가 발생해 사람들이 혼란해 하고 있습니다. 신속히 조치해 주시길 바랍니다.**

기장 : 알겠습니다. 급한 불을 끄시고 퇴로를 확보하여 탈출해주세요!

성공~!

### S#3. 지하철 안

안내창 : 비상 통화 장치 아래에 있는 소화기로 전철 내의 초기 화재를 진압해주세요.

(소화기 발견)

안내창 :  소화기를 잡고 안전핀을 제거하여 소화액을 분사해주세요.

성공 ~!

### S#4. 지하철 안

안내창 : 출입문 옆의 비상 개폐 핸들을 돌려 화살표 방향으로 돌리고, 출입문을 양손으로 잡고 당겨 열어주세요.

성공 ~!

### S#5. 승강장 내

을 착용하세요.

성공 ~!

### S#6. 승강장 통로

안내창 : 방화 셔터에 설치되어 있는 출입구를 밀어서 열고 탈출하세요.

성공~!



## :pencil: C# 을 이용한 TTS 음성파일 

- Program.cs

  - ```c#
    using Google.Cloud.TextToSpeech.V1;
    using System;
    using System.IO;
    
    namespace TextToSpeechApiDemo
    {
        class Program
        {
            static void Main(string[] args)
            {   
                var client = TextToSpeechClient.Create();
                
                // The input to be synthesized, can be provided as text or SSML.
                string[] arr = new string[]{"열차에 화재가 발생했습니다. 주변 사람들에게 화재 발생을 알리세요."
                ,"불이야를 세 번 외쳐주세요"
                ,"지하철 뒤에 있는 비상 통화 장치를 통하여 기장에게 상황을 전달하세요"
                ,"알겠습니다. 급한 불을 끄시고 퇴로를 확보하여 탈출해주세요."
                ,"비상 통화 장치 아래에 있는 소화기로 전철 내의 초기 화재를 진압해주세요."
                ,"소화기를 잡고 안전핀을 제거하여 소화액을 분사해주세요."
                ,"출입문 옆의 비상 개폐 핸들을 돌려 화살표 방향으로 돌리고, 출입문을 양손으로 잡고 당겨 열어주세요."
                ,"승강장 내의 구호 용품 보관함을 찾아 방독면을 착용하세요."
                ,"방화 셔터에 설치되어 있는 출입구를 밀어서 열고 탈출하세요."
                ,"축하합니다. 안전하게 화재현장을 탈출했습니다."};
                int cnt = 1;
                foreach(string a in arr){
                    var input = new SynthesisInput
                    {
                        Text = a
                    };
    
                    // Build the voice request.
                    // 기장목소리 male
                    var voiceSelection = new VoiceSelectionParams
                        {
                            LanguageCode = "ko-KR",
                            SsmlGender = (a == "알겠습니다. 급한 불을 끄시고 퇴로를 확보하여 탈출해주세요.") ? SsmlVoiceGender.Male : SsmlVoiceGender.Female
                        }; 
    
                    // Specify the type of audio file.
                    var audioConfig = new AudioConfig
                    {
                        AudioEncoding = AudioEncoding.Mp3
                    };
    
                    // Perform the text-to-speech request.
                    var response = client.SynthesizeSpeech(input, voiceSelection, audioConfig);
                    
                    // Write the response to the output file.
                    using (var output = File.Create("TTS-" + cnt + ".mp3"))
                    {
                        response.AudioContent.WriteTo(output);
                    }
                    //Console.WriteLine("Audio content written to file \"TTS-" + cnt + ".mp3\"");
                    ++cnt;
                }
            }
        }
    }
    ```

- 결과

  

  ![image-20220922173054074](README.assets/image-20220922173054074.png)

  > mp3 파일만 S07P22A101/VR/Assets/Audio 파일에 저장
