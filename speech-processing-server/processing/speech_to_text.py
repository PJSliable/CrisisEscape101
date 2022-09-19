# 신규 고객에게는 Speech-to-Text에 사용할 수 있는 $300의 무료 크레딧이 제공됩니다. 
# 모든 고객은 매월 60분의 무료 오디오 스크립트 작성 및 분석을 사용할 수 있으며, 크레딧이 차감되지 않습니다.

# 음성 인식(데이터 로깅 제외 - 기본 구성)
# 표준 모델: $0.006/15초** - 무료 크레딧으로 12500시간 사용 가능
# 고급 모델: $0.009/15초** - 무료 크레딧으로 8333시간 20분 사용 가능
# ** 각 요청은 15초 단위로 올림됩니다.

def stt(): # audiofile
    # [START speech_quickstart]
    import io

    # Imports the Google Cloud client library
    # [START migration_import]
    from google.cloud import speech
    # [END migration_import]

    # Instantiates a client
    # [START migration_client]
    client = speech.SpeechClient()
    # [END migration_client]


    speech_file = './sample1.wav'
    with io.open(speech_file, 'rb') as audio_file:
        content = audio_file.read()
        
    audio = speech.RecognitionAudio(content=content)
    
    # audio = audiofile
    config = speech.RecognitionConfig(
        encoding=speech.RecognitionConfig.AudioEncoding.LINEAR16,
        sample_rate_hertz=48000,
        audio_channel_count = 2,
        language_code='ko-KR')

    # Detects speech in the audio file
    response = client.recognize(config=config, audio=audio)
    #print(response)
    for result in response.results:
        stt_text = result.alternatives[0].transcript
        print(stt_text)
        #print('Transcript: {}'.format(result.alternatives[0].transcript))

    return stt_text

if __name__ == '__main__':
    stt()