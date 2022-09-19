from rest_framework.decorators import api_view
from rest_framework.response import Response
from . import speech_to_text
from . import text_similarity

@api_view(['POST'])
def speech_processing(request):
    text = request.POST.get("text")
    speech_file = request.FILES["audio"]

    stt_text = speech_to_text.stt(speech_file)

    sentence = (text, stt_text)
    similarity = text_similarity.ts(sentence)

    if similarity >= 0.6:
        return Response(data={'message':True})
    return Response(data={'message':False})