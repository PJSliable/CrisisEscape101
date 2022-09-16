from rest_framework.decorators import api_view
from rest_framework.response import Response
from . import speech_to_text
from . import text_similarity

@api_view(['GET'])
def speech_processing(request):
    text = request.GET.get("text")
    audiofile = request.FILES["audio"]

    stt_text = speech_to_text.stt(audiofile)

    sentence = (text, stt_text)
    similarity = text_similarity.ts(sentence)

    if similarity >= 0.7:
        return Response(data={'message':True})
    return Response(data={'message':False})