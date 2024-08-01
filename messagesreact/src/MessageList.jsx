import { useEffect, useState } from "react";

/* eslint-disable react/prop-types */
const MessageList = (props)=>{

    const {currentWorker} = props;
    const [messages, setMessages] = useState([]);


    useEffect(()=>{
        async function getMessages() {
            if(!currentWorker) return;
            const res = await fetch(
              `https://localhost:44355/Message/getMessages/${currentWorker.Id}`
            );
            const json = await res.json();
            setMessages(json);
          }
          
        getMessages()
        
    },[currentWorker])

    return (
        <div className="messageList">
            <h2>my messages</h2>
            {messages.map((m,index)=>(
                <p key={index} >{m}</p>

            ))}
        </div>
    )
}

export default MessageList;