from rest_framework.decorators import api_view
from rest_framework.response import Response
from . import speech_to_text
from . import text_similarity
from . import error_rate_cal
import sys

@api_view(['POST'])
def speech_processing(request):
    return Response(data={'message':True})
    text = request.POST.get("text", None)
    
    # speech_file = request.POST.get['audio'] # _bf

    # f = open('./temp.wav’,’wb')
    # f.write(speech_file_bf.encode())
    # f.close()

    # speech_file = open('./temp.wav', 'rb')

    speech_file = request.FILES["audio"]


    # speech_file = request.FILES.get('audio', None)
    # if text == None or speech_file == None:
    #     return Response(data={'message':"text or audio data is invalid"})
    
    
    stt_text = speech_to_text.stt(speech_file)

    sentence = (text, stt_text)
    print('(text, stt_text): ',sentence)
    # text_similarity. 코사인 유사도는 1이 가장 정확하고 나머지는 낮을수록 정확함.
    # similarity = text_similarity.ts(sentence)
    
    # error_rate_cal는 낮을수록 정확
    # 현재까지 cer이 가장 정확했음.
    # EX) "101번 차량에 불이났습니다"
    similarity = error_rate_cal.cer(text, stt_text)
    
    # 정확도 떨어짐
    # similarity = error_rate_cal.wer(text, stt_text)
    
    print('similarity: ',similarity)
    if similarity <= 0.2: # 0.3
        return Response(data={'message':True})
    return Response(data={'message':False})
    