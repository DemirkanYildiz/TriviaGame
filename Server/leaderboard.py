from flask import Flask, request, jsonify
import json

app = Flask(__name__)

@app.route("/leaderboard")
def leaderboard():
    page = request.args.get("page", 0)

    with open(f"data/leaderboard_page_{page}.json") as f:
        return jsonify(json.load(f))

app.run(port=8080)