# Unity AI NPC with Ollama (Llama 3 Local Model)

A Unity demo showing a fully interactive NPC that speaks according to its personality,  
powered by a local LLM (Llama 3 via Ollama) — no API cost required.

---

## 🧩 Features
- Real-time conversation between player and NPC  
- Personality prompt system (`npcPersona`) for different character styles  
- Local AI chat using Ollama (`http://localhost:11434/api/chat`)  
- Simple Unity UI (TMP Input + Button + Dialogue Text)

---

## ⚙️ Setup
1. Install Ollama → <https://ollama.ai>  
2. Run in terminal:
   ```bash
   ollama pull llama3
   ollama serve
