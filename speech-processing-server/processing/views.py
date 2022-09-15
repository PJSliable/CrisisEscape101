from rest_framework.decorators import api_view
from rest_framework.response import Response
from . import speech_to_text
from . import text_similarity

@api_view(['GET'])
def speech_processing(request):
    
    speech_to_text.stt()

    sentence = ()
    text_similarity.ts(sentence)

    a = 0
    if a:
        return Response(data={'message':True})
    return Response(data={'message':False})