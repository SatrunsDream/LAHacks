import sys
import speech_recognition as sr

def returnString(result):
  return str(result)

def transcribe_audio(filename):
  # Initialize recognizer
  r = sr.Recognizer()
  
  # Load audio file
  with sr.AudioFile(filename) as source:
    audio = r.record(source)
  
  # Transcribe audio
  try:
    text = r.recognize_google(audio)
    return text
  except sr.UnknownValueError:
    print("Could not understand audio")
  except sr.RequestError as e:
    print("Error; {0}".format(e))

if __name__ == "__main__":
  audio_file = sys.argv[1]
  text_prompt = transcribe_audio(audio_file)
  
  print(text_prompt)
  returnString(text_prompt)
