# :fire_engine: 위기탈출 1.0.1 :fire_engine: 

![로고](README.assets/logo.png)


## :fire: 위기탈출 1.0.1 소개
위기탈출 1.0.1은 지하철 탑승 중에 화재, 수해 등 재난상황이 발생했을 때의 행동요령을 교육하는 시뮬레이션입니다. VR 및 음성인식 기술을 이용하여 현장감과 몰입도를 높이고 행동요령을 직접 체험함으로써 교육 효과를 높였습니다.

## :fire: 기획배경
최근 호우로 이수역의 사례와 같이 지하철 정거장에서 재난상황이 발생하여 이에 대한 대처의 중요성이 다시 한번 대두되고 있습니다. 현재 지하철에서 재난상황이 발생할 때, 행동요령에 대해 모르는 사람들이 많고, 이론 교육으로 습득한 사람들도 실제로 체험으로 습득할 기회가 없습니다. 위기탈출 1.0.1은 VR기기와 음성인식 기능을 이용하여 기관사에게 재난 상황을 신고하고 출입문을 수동으로 개방하는 등 평소에는 체험할 기회가 없던 행동요령을 효과적으로 교육하기 위해 개발되었습니다.

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
