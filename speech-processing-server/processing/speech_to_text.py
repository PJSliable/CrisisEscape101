def stt(speech_file):
    from google.cloud import speech

    client = speech.SpeechClient()
    
    config = speech.RecognitionConfig(
        encoding=speech.RecognitionConfig.AudioEncoding.LINEAR16,
        sample_rate_hertz=48000,
        audio_channel_count = 1,
        language_code='ko-KR')
    
    content = speech_file.read() 
    audio = speech.RecognitionAudio(content=content)

    response = client.recognize(config=config, audio=audio)
    stt_text = ''
    for result in response.results:
        stt_text = result.alternatives[0].transcript
        print(u"Audio Transcript: {}".format(result.alternatives[0].transcript))
        
    return stt_text
