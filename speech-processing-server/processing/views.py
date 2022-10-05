from rest_framework.decorators import api_view
from rest_framework.response import Response
from . import speech_to_text
from . import error_rate_cal

@api_view(['POST'])
def speech_processing(request):
    text = request.data.get("text", None)
    speech_file = request.FILES.get("audio")
    
    stt_text = speech_to_text.stt(speech_file)

    sentence = (text, stt_text)
    print('(text, stt_text): ',sentence)

    similarity = error_rate_cal.cer(text, stt_text)
    
    if similarity < 0.38:
        return Response(data={'message':'True'})
    return Response(data={'message':'False'})
